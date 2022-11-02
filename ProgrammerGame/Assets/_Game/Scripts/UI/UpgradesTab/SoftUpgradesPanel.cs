using _Game.Data;
using _Game.Scripts.Exception;

namespace _Game.UI.UpgradesTab
{
    public class SoftUpgradesPanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"x{GameData.Instance.MoneyForTapForNewLevel().ToPriceString()} per click";
        protected override string TotalEffectTitle => $"x{GameData.Instance.MoneyForTap().ToPriceString()} per click";

        protected override bool CheckAdditionalBuyAvailability() => true;
    }
}