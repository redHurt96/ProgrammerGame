using AP.ProgrammerGame.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame.Ui
{
    public class WriteCodeButton : BaseActionButton
    {
        protected override void PerformOnClick() =>
            Wallet.Instance.Add(MoneyCalculator.MoneyForCode);
    }
}