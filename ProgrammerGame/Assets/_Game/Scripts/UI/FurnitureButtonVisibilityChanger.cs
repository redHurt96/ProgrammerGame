using AP.ProgrammerGame.Logic;

namespace AP.ProgrammerGame.Ui
{
    public class FurnitureButtonVisibilityChanger : BaseButtonVisibilityChanger
    {
        public override bool CanShowButton => FurnitureUpgradeManager.Instance.CanBuy;
    }
}