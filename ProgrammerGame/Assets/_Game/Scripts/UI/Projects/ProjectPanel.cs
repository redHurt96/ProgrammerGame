using UnityEngine;

namespace AP.ProgrammerGame.UI.Projects
{
    public class ProjectPanel : MonoBehaviour
    {
        [SerializeField] private ProjectSettings _settings;

        [Space]
        [SerializeField] private NotAvailableContent _notAvailableContent;
        [SerializeField] private NotPuchasedContent _notPurchasedContent;
        [SerializeField] private ActiveContent _activeContent;

        private ProjectData _projectData;

        private void Start()
        {
            SetupProjectData();
            UpdatePanel();
            Subscribe();
        }

        private void Subscribe() => 
            _projectData.DataUpdated += UpdatePanel;

        private void OnDestroy()
        {
            if (_projectData != null)
                _projectData.DataUpdated -= UpdatePanel;
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

#if UNITY_EDITOR
        public void Test_Buy25Projects()
        {
            for (int i = 0; i < 25; i++) 
                _projectData.Buy();
        }
#endif

        private void BuyProject() => 
            _projectData.Buy();

        private void RunProject()
        {
            _projectData.Run();
        }

        private void SetupProjectData() => 
            _projectData = GameData.Instance.Projects.Find(x => x.Name == _settings.Name);

        private void SetupNotAvailableContent() => 
            _notAvailableContent.Setup(_settings);

        private void SetupNotPurchasedContent() => 
            _notPurchasedContent.Setup(_projectData, _settings, BuyProject);

        private void SetupOpenContent() => 
            _activeContent.Setup(_projectData, _settings, BuyProject, RunProject);
    }
}