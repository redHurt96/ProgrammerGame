using _Game.Data;
using _Game.Scripts.Exception;

namespace _Game.UI.UpgradesTab
{
    public class SoftUpgradesPanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{GameData.Instance.MoneyForTapForNewLevel.ToPriceString()} per click";
        protected override string TotalEffectTitle => $"{GameData.Instance.MoneyForTap.ToPriceString()} per click";

        protected override bool CheckAdditionalBuyAvailability() => true;
    }
}