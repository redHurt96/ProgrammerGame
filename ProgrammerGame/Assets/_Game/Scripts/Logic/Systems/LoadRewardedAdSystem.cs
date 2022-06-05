using _Game.Common;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class LoadRewardedAdSystem : BaseInitSystem
    {
        private readonly AdsService _ads;
        private readonly AdsEventsService _events;

        public LoadRewardedAdSystem()
        {
            _ads = Services.Get<AdsService>();
            _events = Services.Get<AdsEventsService>();
        }

        public override void Init()
        {
            LoadAd();
            _events.RewardedAdsShown += LoadAd;
        }

        public override void Dispose() => 
            _events.RewardedAdsShown -= LoadAd;

        private void LoadAd() => 
            _ads.LoadRewarded();
    }
}