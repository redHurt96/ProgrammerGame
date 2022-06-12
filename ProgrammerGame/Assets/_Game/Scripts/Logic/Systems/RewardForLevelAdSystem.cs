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
        private readonly EventsMediator _eventsMediator;
        private readonly IAdsService _ads;
        private readonly AdsEvents _adsEvents;
        private readonly GameData _data;
        private readonly Settings _settings;

        public RewardForLevelAdSystem()
        {
            _ads = Services.Get<IAdsService>();
            _data = Services.Get<GameData>();
            _eventsMediator = Services.Get<EventsMediator>();
            _adsEvents = Services.Get<EventsMediator>().Ads;
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
            _eventsMediator.IntentToChangeMoney(money);
        }
    }
}