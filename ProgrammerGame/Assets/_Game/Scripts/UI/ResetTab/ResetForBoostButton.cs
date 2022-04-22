using _Game.Common;
using RH.Utilities.UI;

namespace _Game.UI.ResetTab
{
    public class ResetForBoostButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            _globalEvents.ResetForBoost();
        }
    }
}