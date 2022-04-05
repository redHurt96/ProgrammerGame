using _Game.Common;
using _Game.Configs;

namespace _Game.UI.UpgradesTab
{
    public class InteriorUpgradePanel : BaseUpgradePanel
    {
        public override string EffectTitle => $"+{(int)(Settings.Instance.IncreaseSpeedEffectStrength * 100)}% speed";
        public override string TotalEffectTitle => $"+{GameDataPresenter.Instance.IncreaseSpeedTotalEffect * 100}% speed";
    }
}