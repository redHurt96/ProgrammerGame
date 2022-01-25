using AP.ProgrammerGame.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame.Ui
{
    public class CatchBugButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            Wallet.Instance.Add(MoneyCalculator.MoneyForBug);
    }
}