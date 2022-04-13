using System;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using AP.ProgrammerGame;
using RH.Utilities.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    public class ActiveContent : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _level;
        [SerializeField] private Text _income;
        [SerializeField] private Text _price;
        [SerializeField] private Image _progressBarFill;
        [SerializeField] private Text _timer;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _runButton;
        [SerializeField] private PriceButtonVisibilityComponent priceButtonVisibilityComponent;

        private ProjectData _projectData;

        public void Setup(ProjectData projectData, ProjectSettings settings, Action buyAction, Action runAction)
        {
            _projectData = projectData;

            _icon.sprite = settings.Icon;

            priceButtonVisibilityComponent.SetPriceFunc(() => _projectData.GetPrice(GameData.Instance.BuyCount));

            AddButtonsListeners(buyAction, runAction);
            UpdateContent();
            Subscribe();
        }

        private void AddButtonsListeners(Action buyAction, Action runAction)
        {
            _buyButton.onClick.RemoveAllListeners();
            _buyButton.onClick.AddListener(buyAction.Invoke);
            
            _runButton.onClick.RemoveAllListeners();
            _runButton.onClick.AddListener(runAction.Invoke);
        }

        private void Subscribe()
        {
            GlobalEvents.BuyCountChanged += UpdatePrice;
            _projectData.DynamicDataUpdated += UpdateDynamicContent;
            _projectData.TimeUpdated += UpdateTimerAndProgressBar;
        }

        private void OnDestroy()
        {
            if (_projectData != null)
            {
                _projectData.DynamicDataUpdated -= UpdateDynamicContent;
                _projectData.TimeUpdated -= UpdateTimerAndProgressBar;
            }
        }

        private void UpdateTimerAndProgressBar()
        {
            UpdateTimer();
            UpdateProgressBar();
        }

        private void UpdateDynamicContent()
        {
            UpdatePrice();
            UpdateTimer();
            UpdateProgressBar();
        }

        private void UpdateContent()
        {
            UpdateTitles();
            UpdateProgressBar();
            UpdateTimer();
            DisableRunButtonIfProjectAutorunned();
            UpdatePrice();
        }

        private void UpdatePrice() => 
            _price.text = _projectData.GetPrice(GameData.Instance.BuyCount).ToPriceString();

        private void UpdateProgressBar() => 
            _progressBarFill.fillAmount = _projectData.Progress;

        private void UpdateTimer()
        {
            if (!_projectData.Progress.Approximately(0f) && !_projectData.Progress.Approximately(1f))
                _timer.text = _projectData.CurrentTimeToFinish.ToString(@"h\:mm\:ss");
            else
                _timer.text = TimeSpan.FromSeconds(_projectData.Time).ToString(@"h\:mm\:ss");
        }

        private void UpdateTitles()
        {
            _level.text = $"{_projectData.Level}/{GetCloseLevelTarget(_projectData.Level)}";
            _income.text = _projectData.Income.ToPriceString();
        }

        private string GetCloseLevelTarget(int level) =>
            Settings.Instance.TargetLevels
                .First(x => x > level)
                .ToString();

        private void DisableRunButtonIfProjectAutorunned()
        {
            if (GameData.Instance.SavableData.AutoRunnedProjects.Contains(_projectData.Name) && _runButton.interactable)
                _runButton.interactable = false;
        }
    }
}