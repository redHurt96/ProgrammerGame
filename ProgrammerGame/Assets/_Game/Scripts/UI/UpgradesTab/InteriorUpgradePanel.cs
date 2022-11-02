﻿using System.Linq;
using System.Xml.Schema;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using _Game.UI.ProjectsTab;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public class InteriorUpgradePanel : MonoBehaviour
    {
        [SerializeField] private UpgradeType _upgradeType;

        [Space]
        [SerializeField] private Text _priceTitle;
        [SerializeField] private Text _level;
        [SerializeField] private Text _tip;
        [SerializeField] private Button _buyButton;
        [SerializeField] private PriceButtonVisibilityComponent _buttonVisibilityComponent;
        [SerializeField] private AdsButton _adsButton;
        
        [Space]
        [SerializeField] private int[] _anchorLevels;

        private UpgradeData _interiorUpgradeData;
        private UpgradeData _houseUpgradeData;
        private GameData _data;
        private EventsMediator _events;
        private InteriorSettings _settings;

        private double _price => _settings.GetInteriorPrice(_interiorUpgradeData.Level);
        private string _adsPlacement => $"Upgrade {_upgradeType} to level {_interiorUpgradeData.Level} by ad";

        private void Start()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>().Interior;
            _events = Services.Get<EventsMediator>();
            _interiorUpgradeData = _data.GetUpgradeData(_upgradeType);
            _houseUpgradeData = _data.GetUpgradeData(UpgradeType.House);

            Subscribe();
            UpdateContent();
        }

        private void Subscribe()
        {
            _buttonVisibilityComponent.SetPriceFunc(() => _price);
            _buttonVisibilityComponent.SetAdditionalCondition(CheckBuyAvailability);

            _buyButton.onClick.AddListener(BuyUpgrade);
            _interiorUpgradeData.Upgraded += UpdateContent;
            _houseUpgradeData.Upgraded += UpdateContent;
        }

        private void OnDestroy()
        {
            if (_interiorUpgradeData != null)
                _interiorUpgradeData.Upgraded -= UpdateContent;
            
            if (_houseUpgradeData != null)
                _houseUpgradeData.Upgraded -= UpdateContent;

            _buyButton.onClick.RemoveListener(BuyUpgrade);
        }

        private void UpdateContent()
        {
            _priceTitle.text = _price.ToPriceString();
            _level.text = $"level {_interiorUpgradeData.Level}";
            _tip.enabled = NeedToUpgradeHouse();

            _buttonVisibilityComponent.UpdateVisibility();

            _adsButton.Setup(CanUpgrade, PerformUpgrade, () => _adsPlacement);
        }

        private bool NeedToUpgradeHouse()
        {
            for (int i = 0; i < _anchorLevels.Length; i++)
            {
                if (_anchorLevels[i] == _interiorUpgradeData.Level
                    && _houseUpgradeData.Level <= i)
                    return true;
            }

            return false;
        }

        private bool CanUpgrade() => 
            _price > _data.SavableData.MoneyCount && CheckBuyAvailability();

        private void BuyUpgrade()
        {
            _events.IntentToChangeMoney(-_price);
            PerformUpgrade();
        }

        private void PerformUpgrade() => 
            _events.IntentToBuyUpgrade(_upgradeType);

        private bool CheckBuyAvailability()
        {
            var maxLevel = _settings.InteriorUpgrades.Length;
            var currentLevel = _data.GetUpgradeData(_upgradeType).Level;

            return currentLevel < maxLevel
                && !NeedToUpgradeHouse();
        }
    }
}