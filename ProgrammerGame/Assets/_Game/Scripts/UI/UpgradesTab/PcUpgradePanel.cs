using _Game.Common;
using _Game.Configs;
using _Game.Data;

namespace _Game.UI.UpgradesTab
{
    public class PcUpgradePanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{(int)(_settings.IncreaseMoneyEffectStrength * 100)}% money";
        protected override string TotalEffectTitle => $"+{_gameDataPresenter.IncreaseMoneyTotalEffect * 100}% money";

        protected override bool CheckAdditionalBuyAvailability()
        {
            int pcLevel = _gameDataPresenter.GetUpgradeData(UpgradeType.PC).Level;

            return pcLevel < _settings.PcSettings.FurnitureForPurchase.Length;
        }
    }
}