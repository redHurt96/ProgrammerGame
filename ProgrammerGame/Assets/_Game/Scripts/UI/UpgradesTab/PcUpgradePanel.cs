using _Game.Common;
using _Game.Configs;
using _Game.Data;

namespace _Game.UI.UpgradesTab
{
    public class PcUpgradePanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{(int)(Settings.Instance.IncreaseMoneyEffectStrength * 100)}% money";
        protected override string TotalEffectTitle => $"+{GameData.Instance.IncreaseMoneyTotalEffect * 100}% money";

        protected override bool CheckAdditionalBuyAvailability()
        {
            int pcLevel = GameData.Instance.GetUpgradeData(UpgradeType.PC).Level;

            return pcLevel < Settings.Instance.PcSettings.FurnitureForPurchase.Length;
        }
    }
}