using System;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using RH.Utilities.ServiceLocator;
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
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _runButton;
        [SerializeField] private PriceButtonVisibilityComponent priceButtonVisibilityComponent;

        private ProjectData _projectData;

        private GameData _data;
        private GlobalEvents _events;
        private Settings _settings;

        private void Awake()
        {
            _data = Services.Get<GameData>();
            _events = Services.Get<GlobalEvents>();
            _settings = Services.Get<Settings>();
        }

        public void Setup(ProjectData projectData, ProjectSettings settings, Action buyAction, Action runAction)
        {
            _projectData = projectData;

            _icon.sprite = settings.Icon;

            priceButtonVisibilityComponent.SetPriceFunc(() => _projectData.GetPrice(_data.BuyCount));

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
            _events.BuyCountChanged += UpdatePrice;

            _projectData.DynamicDataUpdated += UpdateDynamicContent;
            _projectData.TimeUpdated += UpdateProgressBar;
        }

        private void OnDestroy()
        {
            _events.BuyCountChanged -= UpdatePrice;

            if (_projectData != null)
            {
                _projectData.DynamicDataUpdated -= UpdateDynamicContent;
                _projectData.TimeUpdated -= UpdateProgressBar;
            }
        }

        private void UpdateDynamicContent()
        {
            UpdatePrice();
            UpdateProgressBar();
        }

        private void UpdateContent()
        {
            UpdateTitles();
            UpdateProgressBar();
            DisableRunButtonIfProjectAutorunned();
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            priceButtonVisibilityComponent.UpdateVisibility();
            _price.text = _projectData.GetPrice(_data.BuyCount).ToPriceString();
        }

        private void UpdateProgressBar() => 
            _progressBarFill.fillAmount = _projectData.Progress;

        private void UpdateTitles()
        {
            _level.text = $"{_projectData.Level}/{GetCloseLevelTarget(_projectData.Level)}";
            _income.text = _projectData.Income.ToPriceString();
        }

        private string GetCloseLevelTarget(int level) =>
            _settings.TargetLevels
                .First(x => x > level)
                .ToString();

        private void DisableRunButtonIfProjectAutorunned()
        {
            if (_data.IsProjectAutoRunned(_projectData.Name) && _runButton.interactable)
                _runButton.interactable = false;
        }
    }
}