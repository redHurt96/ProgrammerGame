using _Game.Common;
using RH.Utilities.UI;

namespace _Game.UI.Buttons
{
    public class SpeedUpCodeWritingButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            GlobalEvents.AccelerateCoding();
    }
}