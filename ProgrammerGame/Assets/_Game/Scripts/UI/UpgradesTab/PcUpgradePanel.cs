using _Game.Common;
using _Game.Configs;
using _Game.Data;

namespace _Game.UI.UpgradesTab
{
    public class PcUpgradePanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{(int)(Settings.Instance.IncreaseMoneyEffectStrength * 100)}% money";
        protected override string TotalEffectTitle => $"+{GameDataPresenter.Instance.IncreaseMoneyTotalEffect * 100}% money";

        protected override bool CheckAdditionalBuyAvailability()
        {
            int pcLevel = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.PC).Level;

            return pcLevel < Settings.Instance.PcSettings.FurnitureForPurchase.Length;
        }
    }
}