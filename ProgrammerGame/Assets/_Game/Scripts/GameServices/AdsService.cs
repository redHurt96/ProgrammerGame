using System;
using _Game.Configs;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public class AdsService : IAdsService
    {
        private readonly Settings _settings;
        private readonly InterstitialProvider _interstitialProvider;
        private readonly RewardedProvider _rewardedProvider;
        private readonly BannerProvider _bannerProvider;

        public AdsService()
        {
            _settings = Services.Get<Settings>();
            IronSource.Agent.init(_settings.Ads.AppId);

            _interstitialProvider = new InterstitialProvider();
            _rewardedProvider = new RewardedProvider();
            _bannerProvider = new BannerProvider();
        }

        public bool IsInterstitialReady => _interstitialProvider.IsReady;
        public void LoadInterstitial() => _interstitialProvider.Load();
        public void ShowInterstitial() => _interstitialProvider.Show();

        public bool IsRewardedReady => _rewardedProvider.IsReady;
        public void LoadRewarded() => _rewardedProvider.Load();
        public void ShowRewarded(string placement, Action onSuccess)
        {
            UnityEngine.Debug.Log("AdsService - show rewarded ad from " + placement);
            _rewardedProvider.Show(onSuccess);
        }

        public void LoadBanner() => 
            _bannerProvider.Load();
    }
}