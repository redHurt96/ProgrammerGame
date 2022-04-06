﻿using System;
using System.Linq;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using AP.ProgrammerGame.UI.Projects;
using UnityEngine;

namespace _Game.UI.Projects
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

        private void BuyProject()
        {
            GlobalEvents.IntentToChangeMoney(-_projectData.Price);
            _projectData.Buy();
        }

        private void RunProject() => 
            GlobalEvents.IntentToRunProject(_projectData);

        private void SetupProjectData() => 
            _projectData = GameData.Instance.SavableData.Projects.Find(x => x.Name == settings.Name);

        private void SetupNotAvailableContent() => 
            _notAvailableContent.Setup(settings);

        private void SetupNotPurchasedContent() => 
            _notPurchasedContent.Setup(_projectData, settings, BuyProject);

        private void SetupOpenContent() => 
            _activeContent.Setup(_projectData, settings, BuyProject, RunProject);

#if UNITY_EDITOR
        public void Test_Buy25Projects()
        {
            for (int i = 0; i < 25; i++) 
                _projectData.Buy();
        }

        public void Test_ForceComplete() =>
            GameData.Instance.RunnedProjects
                .First(x => x.ProjectData.Name == settings.Name)
                .Test_ForceComplete();
#endif
    }
}