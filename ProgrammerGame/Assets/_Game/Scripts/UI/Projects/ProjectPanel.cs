using System;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI.Projects
{
    public class ProjectPanel : MonoBehaviour
    {
        [SerializeField] private ProjectSettings _settings;
        [SerializeField] private ProjectSettings _previousProjectSettings;

        [Space]
        [SerializeField] private Image _icon;

        [Space]
        [SerializeField] private NotAvailableContent _notAvailableContent;
        [SerializeField] private NotPuchasedContent _notPurchasedContent;
        [SerializeField] private ActiveContent _activeContent;

        private ProjectData _projectData;

        private void Start()
        {
            SetupProjectData();
            SetupIcon();
            UpdatePanel();
            Subscribe();
        }

        private void Subscribe()
        {
            _projectData.Purchased += UpdatePanel;
        }

        private void OnDestroy()
        {
            _projectData.Purchased -= UpdatePanel;
        }

        public void UpdatePanel()
        {
            switch (_projectData.ProjectState)
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

        private void BuyProject()
        {
            throw new NotImplementedException();
        }

        private void SetupProjectData() => 
            _projectData = GameData.Instance.Projects.Find(x => x.Name == _settings.Name);

        private void SetupIcon() => 
            _icon.sprite = _settings.Icon;

        private void SetupNotAvailableContent() => 
            _notAvailableContent.Setup(_settings, _previousProjectSettings);

        private void SetupNotPurchasedContent() => 
            _notPurchasedContent.Setup(_projectData, BuyProject);

        private void SetupOpenContent() => 
            _activeContent.Setup(_projectData);
    }
}