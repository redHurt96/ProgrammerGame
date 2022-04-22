using _Game.Common;
using _Game.Scripts.Exception;

namespace _Game.UI.UpgradesTab
{
    public class SoftUpgradesPanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{_gameDataPresenter.MoneyForTapForNewLevel.ToPriceString()} per click";
        protected override string TotalEffectTitle => $"{_gameDataPresenter.MoneyForTap.ToPriceString()} per click";

        protected override bool CheckAdditionalBuyAvailability() => true;
    }
}