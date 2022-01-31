using RH.Utilities.UI;

namespace AP.ProgrammerGame_v2.UI
{

    public class SpeedUpCodeWritingButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            GlobalEvents.AccelerateCoding();
    }
}