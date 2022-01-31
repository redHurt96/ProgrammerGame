using AP.ProgrammerGame.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame.Ui
{
    public class BuyHouseButton : BaseActionButton
    {
        protected override void PerformOnClick() => HouseUpgradeManager.Instance.Buy();
    }
}