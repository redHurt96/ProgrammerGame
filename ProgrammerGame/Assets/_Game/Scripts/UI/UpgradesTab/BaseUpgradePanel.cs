using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using _Game.Scripts.Exception;
using _Game.UI.ProjectsTab;
using AP.ProgrammerGame;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public abstract class BaseUpgradePanel : MonoBehaviour
    {
        [SerializeField] private BaseScriptablePriceSettings priceSettingsScriptable;
        [SerializeField] private UpgradeType _upgradeType;

        [Space]
        [SerializeField] private Text _priceTitle;
        [SerializeField] private Text _effect;
        [SerializeField] private Text _level;
        [SerializeField] private Text _totalEffect;
        [SerializeField] private Button _buyButton;
        [SerializeField] private PriceButtonVisibilityComponent _buttonVisibilityComponent;
        [SerializeField] private AdsButton _adsButton;

        private UpgradeData _upgradeData;

        private GameData _data;
        private EventsMediator _events;

        private double _price => priceSettingsScriptable.GetPrice(_upgradeData.Level);
        private string _adsPlacementText => $"Upgrade {_upgradeType} to level {_upgradeData.Level} by ad";

        protected abstract string EffectTitle { get; }
        protected abstract string TotalEffectTitle { get; }

        protected abstract bool CheckAdditionalBuyAvailability();

        private void Start()
        {
            _data = Services.Get<GameData>();
            _events = Services.Get<EventsMediator>();
            _upgradeData = _data.GetUpgradeData(_upgradeType);

            Subscribe();
            UpdateContent();
        }

        private void Subscribe()
        {
            _buyButton.onClick.AddListener(BuyUpgrade);
            _buttonVisibilityComponent.SetPriceFunc(() => _price);
            _buttonVisibilityComponent.SetAdditionalCondition(CheckAdditionalBuyAvailability);
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

            _effect.text = EffectTitle;
            _totalEffect.text = TotalEffectTitle;
            
            _buttonVisibilityComponent.UpdateVisibility();

            _adsButton.Setup(CanUpgrade, PerformUpgrade, () => _adsPlacementText);
        }

        private bool CanUpgrade() => 
            _price > _data.SavableData.MoneyCount && CheckAdditionalBuyAvailability();

        private void BuyUpgrade()
        {
            _events.IntentToChangeMoney(-_price);
            PerformUpgrade();
        }

        private void PerformUpgrade() => 
            _events.IntentToBuyUpgrade(_upgradeType);
    }
}
