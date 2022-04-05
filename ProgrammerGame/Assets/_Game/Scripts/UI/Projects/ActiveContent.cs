using System;
using System.Linq;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using AP.ProgrammerGame;
using RH.Utilities.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Projects
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

            priceButtonVisibilityComponent.SetPriceFunc(() => _projectData.Price);

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

        private void Subscribe() => 
            _projectData.DataUpdated += UpdateContent;

        private void OnDestroy()
        {
            if (_projectData != null)
                _projectData.DataUpdated -= UpdateContent;
        }

        private void UpdateContent()
        {
            UpdateTitles();
            UpdateProgressBar();
            UpdateTimer();
            DisableRunButtonIfProjectAutorunned();
        }

        private void UpdateProgressBar()
        {
            _progressBarFill.fillAmount = _projectData.Progress;
        }

        private void UpdateTimer()
        {
            if (!_projectData.Progress.Approximately(0f) && !_projectData.Progress.Approximately(1f))
                _timer.text = _projectData.CurrentTimeToFinish.ToString(@"h\:mm\:ss");
            else
                _timer.text = TimeSpan.FromSeconds(_projectData.BaseTime).ToString(@"h\:mm\:ss");
        }

        private void UpdateTitles()
        {
            _level.text = $"{_projectData.Level}/{GetCloseLevelTarget(_projectData.Level)}";
            _income.text = _projectData.Income.ToPriceString();
            _price.text = _projectData.Price.ToPriceString();
        }

        private string GetCloseLevelTarget(int level) =>
            Settings.Instance.TargetLevels
                .First(x => x > level)
                .ToString();

        private void DisableRunButtonIfProjectAutorunned()
        {
            if (GameData.Instance.AutoRunnedProjects.Contains(_projectData.Name) && _runButton.interactable)
                _runButton.interactable = false;
        }
    }
}