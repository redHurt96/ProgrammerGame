using RH.Utilities.UI;

namespace AP.ProgrammerGame_v2.UI
{
    public class CatchBugButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            GlobalEvents.CatchBug();
    }
}