using _Game.Common;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class AdsOnPauseEventProvider : BaseInitSystem
    {
        private readonly EventsMediator _eventsMediator;
        private readonly IAdsService _ads;

        public AdsOnPauseEventProvider()
        {
            _ads = Services.Get<IAdsService>();
            _eventsMediator = Services.Get<EventsMediator>();
        }

        public override void Init() => 
            _eventsMediator.ApplicationPausedWIthStatus += SendToAds;

        public override void Dispose() => 
            _eventsMediator.ApplicationPausedWIthStatus -= SendToAds;

        private void SendToAds(bool pauseStatus) => 
            _ads.OnApplicationPause(pauseStatus);
    }
}