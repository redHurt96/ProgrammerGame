using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using UnityEngine;

namespace _Game.UI.ProjectsTab
{
    public class ProjectPanel : MonoBehaviour
    {
        [SerializeField] private ProjectSettings settings;

        [Space]
        [SerializeField] private NotAvailableContent _notAvailableContent;
        [SerializeField] private NotPurchasedContent _notPurchasedContent;
        [SerializeField] private ActiveContent _activeContent;

        private ProjectData _projectData;

        private void Start()
        {
            SetupProjectData();
            UpdatePanel();
            Subscribe();
        }

        private void Subscribe() => 
            _projectData.MainDataUpdated += UpdatePanel;

        private void OnDestroy()
        {
            if (_projectData != null)
                _projectData.MainDataUpdated -= UpdatePanel;
        }

        public void UpdatePanel()
        {
            switch (_projectData.State)
            {
                case ProjectState.NotAvailable:
                    SetupNotAvailableContent();
                    _notAvailableContent.gameObject.SetActive(true);
                    _notPurchasedContent.gameObject.SetActive(false);
                    _activeContent.gameObject.SetActive(false);
                    break;
                case ProjectState.NotPurchased:
                    SetupNotPurchasedContent();
                    _notAvailableContent.gameObject.SetActive(false);
                    _notPurchasedContent.gameObject.SetActive(true);
                    _activeContent.gameObject.SetActive(false);
                    break;
                case ProjectState.Active:
                    SetupOpenContent();
                    _notAvailableContent.gameObject.SetActive(false);
                    _notPurchasedContent.gameObject.SetActive(false);
                    _activeContent.gameObject.SetActive(true);
                    break;
            }
        }

        private void BuyProjectOnce() => 
            BuyProjectMultipleTimes(1);

        private void BuyProject() => 
            BuyProjectMultipleTimes(GameData.Instance.BuyCount);

        private void BuyProjectMultipleTimes(int buyCount)
        {
            GlobalEvents.IntentToChangeMoney(-_projectData.GetPrice(buyCount));
            _projectData.Buy(buyCount);
        }

        private void RunProject() => 
            GlobalEvents.IntentToRunProject(_projectData);

        private void SetupProjectData() => 
            _projectData = GameData.Instance.SavableData.Projects.Find(x => x.Name == settings.Name);

        private void SetupNotAvailableContent() => 
            _notAvailableContent.Setup(settings);

        private void SetupNotPurchasedContent() => 
            _notPurchasedContent.Setup(_projectData, settings, BuyProjectOnce);

        private void SetupOpenContent() => 
            _activeContent.Setup(_projectData, settings, BuyProject, RunProject);

#if UNITY_EDITOR
        public void Test_Buy25Projects() => 
            _projectData.Buy(25);

        public void Test_ForceComplete() =>
            GameData.Instance.RunnedProjects
                .First(x => x.ProjectData.Name == settings.Name)
                .Test_ForceComplete();
#endif
    }
}