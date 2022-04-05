using System.Linq;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using _Game.UI.Projects;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public abstract class BaseUpgradePanel : MonoBehaviour
    {
        [SerializeField] private PriceSettings _priceSettings;
        [SerializeField] private UpgradeType _upgradeType;

        [Space]
        [SerializeField] private Text _priceTitle;
        [SerializeField] private Text _effect;
        [SerializeField] private Text _level;
        [SerializeField] private Text _totalEffect;
        [SerializeField] private Button _buyButton;
        [SerializeField] private PriceButtonVisibilityComponent _buttonVisibilityComponent;

        private UpgradeData _upgradeData;
        private long _price => _priceSettings.GetPrice(_upgradeData.Level);

        public abstract string EffectTitle { get; }
        public abstract string TotalEffectTitle { get; }

        private void Start()
        {
            _upgradeData = GameData.Instance.Upgrades.First(x => x.Type == _upgradeType);

            UpdateContent();
            Subscribe();
        }

        private void Subscribe()
        {
            _buyButton.onClick.AddListener(BuyUpgrade);
            _buttonVisibilityComponent.SetPriceFunc(() => _price);
            _upgradeData.Upgraded += UpdateContent;
        }

        private void OnDestroy()
        {
            if (_upgradeData != null)
                _upgradeData.Upgraded += UpdateContent;

            _buyButton.onClick.RemoveListener(BuyUpgrade);
        }

        private void UpdateContent()
        {
            _priceTitle.text = _price.ToPriceString();
            _level.text = $"level {_upgradeData.Level}";

            _effect.text = EffectTitle;
            _totalEffect.text = TotalEffectTitle;
        }


        private void BuyUpgrade() => 
            GlobalEvents.IntentToBuyUpgrade(_upgradeType, _price);
    }
}
