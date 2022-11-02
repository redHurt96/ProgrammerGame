﻿using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using _Game.Scripts.Exception;
using _Game.UI.ProjectsTab;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProgrammersTab
{
    public class ProgrammerPanel : MonoBehaviour
    {
        [SerializeField] private ProgrammerSettings _programmer;

        [Space]
        [SerializeField] private Text _name;
        [SerializeField] private Text _description;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        [SerializeField] private Text _price;
        [SerializeField] private PriceButtonVisibilityComponent _priceButtonVisibilityComponent;
        [SerializeField] private Text _needUpgradeTip;
        [SerializeField] private Text _buttonTitle;
        [SerializeField] private AdsButton _adsButton;

        private Apartment _apartment;
        private GameData _data;
        private EventsMediator _eventsMediator;
        private Settings _settings;

        private string _adPlacementForUpgrade =>
            $"Upgrade programmer for project {_programmer.AutomatedProject.Name} " +
            $"to level {_data.GetProgrammerUpgradeData(_programmer.AutomatedProject.Name).Level}";
        
        private string _adPlacementForBuy =>
            $"Buy programmer for project {_programmer.AutomatedProject.Name} " +
            $"- level {_data.GetProgrammerUpgradeData(_programmer.AutomatedProject.Name).Level}";

        private int _level => _data.GetProgrammerUpgradeData(_programmer.AutomatedProject.Name).Level;

        private bool _isPurchased =>
            _data.SavableData.AutoRunnedProjects.Any(x => x.ProjectName == _programmer.AutomatedProject.Name);

        private void OnEnable()
        {
            _apartment ??= Services.Get<Apartment>();
            _data ??= Services.Get<GameData>();
            _settings ??= Services.Get<Settings>();
            _eventsMediator ??= Services.Get<EventsMediator>();

            UpdateTip();
            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void Start()
        {
            SetupCommonData();

            if (_isPurchased)
                SetupForPurchasedProgrammer();
            else
                SetupForAvailableProgrammer();

            _eventsMediator.OnUpgraded += UpdateTip;

            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void OnDestroy() => 
            _eventsMediator.OnUpgraded -= UpdateTip;

        private void SetupCommonData()
        {
            _name.text = _programmer.Name + GetPost();
            _icon.sprite = _programmer.Icon;
        }

        private string GetPost()
        {
            if (!_isPurchased)
                return string.Empty;
            
            if (_level < 4)
                return " (junior)";
            if (_level < 7)
                return " (middle)";
            if (_level < 10)
                return " (senior)";
            
            return " (CTO)";
        }

        private void SetupForPurchasedProgrammer()
        {
            ProgrammerUpgradeData upgradeData = _data.GetProgrammerUpgradeData(_programmer.AutomatedProject.Name);
            bool canUpgrade = CheckProgrammerHasUpgrade();

            _description.text = $"+ {upgradeData.Level * _settings.AllProgrammersSettings.BoostPerProgrammerLevel * 100}% money";
            _button.gameObject.SetActive(canUpgrade);

            if (canUpgrade)
            {
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(UpgradeProgrammer);

                _buttonTitle.text = "Upgrade";

                _button.gameObject.SetActive(CheckProgrammerHasUpgrade());
                _priceButtonVisibilityComponent.SetPriceFunc(() => _programmer.GetPrice(upgradeData.Level));
                _priceButtonVisibilityComponent.SetAdditionalCondition(CheckProgrammerHasUpgrade);
                _price.text = _programmer.GetPrice(upgradeData.Level).ToPriceString();

                _adsButton.Setup(
                    () => CheckProgrammerHasUpgrade() && _data.SavableData.MoneyCount < _programmer.GetPrice(upgradeData.Level), 
                    PerformUpgrade,
                    () => _adPlacementForUpgrade);
            }
        }

        private void SetupForAvailableProgrammer()
        {
            _description.text = $"{_programmer.AutomatedProject.Name} auto run";

            _price.text = _programmer.GetPrice(0).ToPriceString();
            _button.onClick.AddListener(BuyProgrammer);
            _priceButtonVisibilityComponent.SetPriceFunc(() => _programmer.GetPrice(0));
            _priceButtonVisibilityComponent.SetAdditionalCondition(CheckProgrammerAvailability);
            _buttonTitle.text = "Hire";

            _adsButton.Setup(
                () => CheckProgrammerAvailability() && _data.SavableData.MoneyCount < _programmer.GetPrice(0), 
                PerformBuy,
                () => _adPlacementForBuy);

            UpdateTip();
        }

        private bool CheckProgrammerAvailability() =>
            _apartment.ContainSpotFor(_programmer.Name)
            && _data.SavableData.Projects
                .First(x => x.projectSettings == _programmer.AutomatedProject)
                .State == ProjectState.Active;

        private void BuyProgrammer()
        {
            PerformBuy();
            _eventsMediator.IntentToChangeMoney(-_programmer.GetPrice(0));
        }

        private void PerformBuy()
        {
            _eventsMediator.IntentToBuyProgrammer(_programmer.AutomatedProject.Name);
            SetupForPurchasedProgrammer();
        }

        private void UpgradeProgrammer()
        {
            _eventsMediator.IntentToChangeMoney(-_programmer.GetPrice(_data.GetProgrammerUpgradeData(_programmer.AutomatedProject.Name).Level));
            PerformUpgrade();
            _name.text = _programmer.Name + GetPost();
        }

        private void PerformUpgrade()
        {
            _eventsMediator.IntentToUpgradeProgrammer(_programmer.AutomatedProject.Name);
            SetupForPurchasedProgrammer();
        }

        private void UpdateTip(UpgradeType type)
        {
            if (type == UpgradeType.Interior)
                UpdateTip();
        }

        private void UpdateTip() => 
            _needUpgradeTip.gameObject.SetActive(!_apartment.ContainSpotFor(_programmer.Name));

        private bool CheckProgrammerHasUpgrade()
        {
            int upgradesCount = _settings.AllProgrammersSettings.Upgrades.Length;

            return _level < upgradesCount;
        }
    }
}