using _Game.Common;

namespace _Game.UI.UpgradesTab
{
    public class HouseUpgradePanel : BaseUpgradePanel
    {
        public override string EffectTitle => $"+{(GameDataPresenter.Instance.NewProgrammersCount * 100)} programmers";
        public override string TotalEffectTitle => $"{GameDataPresenter.Instance.TotalProgrammersCount} programmers";
    }
}