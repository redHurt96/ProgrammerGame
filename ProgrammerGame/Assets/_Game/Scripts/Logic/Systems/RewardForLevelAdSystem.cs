using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class RewardForLevelAdSystem : BaseInitSystem
    {
        private readonly GlobalEvents _events;
        private readonly AdsService _ads;
        private readonly AdsEventsService _adsEvents;
        private readonly GameData _data;
        private readonly Settings _settings;

        public RewardForLevelAdSystem()
        {
            _ads = Services.Get<AdsService>();
            _data = Services.Get<GameData>();
            _events = Services.Get<GlobalEvents>();
            _adsEvents = Services.Get<AdsEventsService>();
            _settings = Services.Get<Settings>();
        }

        public override void Init() => 
            _adsEvents.OnRewardForLevelIntent += ShowAd;

        public override void Dispose() => 
            _adsEvents.OnRewardForLevelIntent -= ShowAd;

        private void ShowAd() => 
            _ads.ShowRewarded("Level reward", PerformOnSuccess);

        private void PerformOnSuccess()
        {
            double money = _data.GetRewardForLevel() * (_settings.Ads.ResetBoost - 1);
            _events.IntentToChangeMoney(money);

            _adsEvents.InvokeOnRewardedAdsShown();
        }
    }
}