using System;
using _Game.Configs;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public class AdsService : IService
    {
        private readonly Settings _settings;
        private readonly InterstitialProvider _interstitialProvider;
        private readonly RewardedProvider _rewardedProvider;

        public AdsService()
        {
            _settings = Services.Get<Settings>();
            IronSource.Agent.init(_settings.Ads.AppId);

            _interstitialProvider = new InterstitialProvider();
            _rewardedProvider = new RewardedProvider();
        }

        public bool IsInterstitialReady => _interstitialProvider.IsReady;
        public void LoadInterstitial(Action onLoaded = null) => _interstitialProvider.Load(onLoaded);
        public void ShowInterstitial() => _interstitialProvider.Show();

        public bool IsRewardedReady => _rewardedProvider.IsReady;
        public void LoadRewarded() => _rewardedProvider.Load();
        public void ShowRewarded(string placement, Action onSuccess) => _rewardedProvider.Show(onSuccess);
    }
}