using System;
using _Game.Configs;
using _Game.Data;
using _Game.Extensions;
using GameAnalyticsSDK;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public class AdsService : IAdsService
    {
        private readonly Settings _settings;
        private readonly GameData _data;
        
        private readonly InterstitialProvider _interstitialProvider;
        private readonly RewardedProvider _rewardedProvider;
        private readonly BannerProvider _bannerProvider;

        public AdsService()
        {
            _settings = Services.Get<Settings>();
            _data = Services.Get<GameData>();
            
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
            GameAnalytics.NewDesignEvent(placement, _data.ToDictionary());
            _rewardedProvider.Show(placement, onSuccess);
        }

        public bool IsBannerShown => _bannerProvider.IsShown;
        
        public void LoadBanner() => 
            _bannerProvider.Load();

        public void Dispose()
        {
            _rewardedProvider?.Dispose();
            _bannerProvider?.Dispose();
        }
    }
}