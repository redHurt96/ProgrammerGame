using _Game.Common;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.UI.Ads
{
    public class CoffeeBreakButton : BaseActionButton
    {
        private AdsEventsService _events;

        protected override void PerformOnStart() => 
            _events = Services.Get<AdsEventsService>();

        protected override void PerformOnClick() => 
            _events.CoffeeBreakIntent();
    }
}