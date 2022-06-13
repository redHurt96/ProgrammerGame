using _Game.Common;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.Ads.Ui
{
    public class CoffeeBreakButton : BaseActionButton
    {
        private AdsEvents _events;

        protected override void PerformOnStart() => 
            _events = Services.Get<EventsMediator>().Ads;

        protected override void PerformOnClick() => 
            _events.CoffeeBreakIntent();
    }
}