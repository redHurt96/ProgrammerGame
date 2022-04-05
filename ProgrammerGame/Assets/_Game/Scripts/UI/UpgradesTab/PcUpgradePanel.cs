using _Game.Common;
using _Game.Configs;

namespace _Game.UI.UpgradesTab
{
    public class PcUpgradePanel : BaseUpgradePanel
    {
        public override string EffectTitle => $"+{(int)(Settings.Instance.IncreaseMoneyEffectStrength * 100)}% money";
        public override string TotalEffectTitle => $"+{GameDataPresenter.Instance.IncreaseMoneyTotalEffect * 100}% money";
    }
}