using RH.Utilities.UI;

namespace AP.ProgrammerGame.UI
{
    public class CatchBugButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            GlobalEvents.CatchBug();
    }
}