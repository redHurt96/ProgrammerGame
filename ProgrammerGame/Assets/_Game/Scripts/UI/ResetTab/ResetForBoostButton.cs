using _Game.Common;
using AP.ProgrammerGame;
using RH.Utilities.UI;

namespace _Game.UI.ResetTab
{
    public class ResetForBoostButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            GlobalEvents.ResetForBoost();
        }
    }
}