using _Game.Common;
using _Game.GameServices;
using _Game.GameServices.Analytics;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class LoadRewardedAdSystem : BaseInitSystem
    {
        private readonly IAdsService _ads;
        private readonly AdsEvents _events;

        public LoadRewardedAdSystem()
        {
            _ads = Services.Get<IAdsService>();
            _events = Services.Get<EventsMediator>().Ads;
        }

        public override void Init()
        {
            LoadAd();
            _events.RewardedAdsShown += LoadAd;
        }

        public override void Dispose() => 
            _events.RewardedAdsShown -= LoadAd;

        private void LoadAd(AdsEventType adsEventType, AdType adType, string arg3, string arg4) =>
            LoadAd();
        
        private void LoadAd() => 
            _ads.LoadRewarded();
    }
}