using _Game.Common;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class AdsOnPauseEventProvider : BaseInitSystem
    {
        private readonly GlobalEvents _events;

        public AdsOnPauseEventProvider() => 
            _events = Services.Get<GlobalEvents>();

        public override void Init() => 
            _events.ApplicationPausedWIthStatus += SendToAds;

        public override void Dispose() => 
            _events.ApplicationPausedWIthStatus -= SendToAds;

        private void SendToAds(bool pauseStatus) => 
            IronSource.Agent.onApplicationPause(pauseStatus);
    }
}