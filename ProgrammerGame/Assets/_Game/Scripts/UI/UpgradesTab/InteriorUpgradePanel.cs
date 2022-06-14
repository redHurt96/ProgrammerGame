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
        [SerializeField] private Button _buyButton;
        [SerializeField] private PriceButtonVisibilityComponent _buttonVisibilityComponent;
        [SerializeField] private AdsButton _adsButton;

        private UpgradeData _upgradeData;

        private GameData _data;
        private EventsMediator _events;
        private InteriorSettings _settings;

        private double _price => _settings.GetPrice(_upgradeData.Level);

        private void Start()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>().Interior;
            _events = Services.Get<EventsMediator>();
            _upgradeData = _data.GetUpgradeData(_upgradeType);

            Subscribe();
            UpdateContent();
        }

        private void Subscribe()
        {
            _buyButton.onClick.AddListener(BuyUpgrade);
            _buttonVisibilityComponent.SetPriceFunc(() => _price);
            _buttonVisibilityComponent.SetAdditionalCondition(CheckBuyAvailability);
            _upgradeData.Upgraded += UpdateContent;
        }

        private void OnDestroy()
        {
            if (_upgradeData != null)
                _upgradeData.Upgraded -= UpdateContent;

            _buyButton.onClick.RemoveListener(BuyUpgrade);
        }

        private void UpdateContent()
        {
            _priceTitle.text = _price.ToPriceString();
            _level.text = $"level {_upgradeData.Level}";

            _buttonVisibilityComponent.UpdateVisibility();

            _adsButton.Setup(CanUpgrade, PerformUpgrade);
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
            var maxLevel = _settings.FurnitureForPurchase.Count;
            var currentLevel = _data.GetUpgradeData(UpgradeType.Interior).Level;

            return currentLevel < maxLevel;
        }
    }
}