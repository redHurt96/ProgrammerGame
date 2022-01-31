using AP.ProgrammerGame.Logic;

namespace AP.ProgrammerGame.Ui
{
    public class HouseButtonVisibilityChanger : BaseButtonVisibilityChanger
    {
        public override bool CanShowButton => HouseUpgradeManager.Instance.CanBuy;
    }
}