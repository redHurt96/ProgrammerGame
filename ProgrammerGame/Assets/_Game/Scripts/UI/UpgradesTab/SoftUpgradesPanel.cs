using _Game.Common;
using _Game.Scripts.Exception;

namespace _Game.UI.UpgradesTab
{
    public class SoftUpgradesPanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{GameDataPresenter.Instance.MoneyForTapForNewLevel.ToPriceString()} per click";
        protected override string TotalEffectTitle => $"{GameDataPresenter.Instance.MoneyForTap.ToPriceString()} per click";

        protected override bool CheckAdditionalBuyAvailability() => true;
    }
}