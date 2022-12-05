using _Game.Configs;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.UpgradesTab
{
    public abstract class MaxUpgradesInteractor : MonoBehaviour
    {
        [SerializeField] private UpgradeType _upgradeType;

        private GameData _data;
        private UpgradeData _upgradeData;
        private Settings _settings;

        protected bool IsMaxLevelReached()
        {
            switch (_upgradeType)
            {
                case UpgradeType.Interior:
                    return _upgradeData.Level >= _settings.Interior.InteriorUpgrades.Length;
                case UpgradeType.PC:
                    return _upgradeData.Level >= _settings.Interior.PcUpgrades.Length;
                case UpgradeType.House:
                    return _upgradeData.Level >= _settings.Interior.HouseUpgrades.Length;
                case UpgradeType.Soft:
                default:
                    return false;
            }
        }

        private void Start()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
            _upgradeData = _data.GetUpgradeData(_upgradeType);

            UpdateTipVisibility();
            
            _upgradeData.Upgraded += UpdateTipVisibility;
        }

        private void OnDestroy()
        {
            if (_upgradeData != null)
                _upgradeData.Upgraded -= UpdateTipVisibility;
        }

        protected abstract void UpdateTipVisibility();
    }
}