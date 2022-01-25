using AP.ProgrammerGame.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame.Ui
{
    public class BuyFurnitureButton : BaseActionButton
    {
        protected override void PerformOnClick() => FurnitureUpgradeManager.Instance.Buy();
    }
}