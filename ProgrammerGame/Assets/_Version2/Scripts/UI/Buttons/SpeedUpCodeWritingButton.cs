using RH.Utilities.UI;

namespace AP.ProgrammerGame.UI
{

    public class SpeedUpCodeWritingButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            GlobalEvents.AccelerateCoding();
    }
}