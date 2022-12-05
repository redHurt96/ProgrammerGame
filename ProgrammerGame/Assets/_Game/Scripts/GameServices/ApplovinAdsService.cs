using System;
using _Game.Configs;
using _Game.Debug.GameServices;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public class ApplovinAdsService : IAdsService
    {
        public bool IsInterstitialReady => _interstitialProvider.IsReady;
        public bool IsRewardedReady => _rewardedProvider.IsReady;
        public bool IsBannerShown => false;

        private readonly InterstitialProvider _interstitialProvider;
        private readonly RewardedProvider _rewardedProvider;
        private readonly Settings _settings;

        public ApplovinAdsService()
        {
            _settings = Services.Get<Settings>();
            
            _interstitialProvider = new InterstitialProvider();
            _rewardedProvider = new RewardedProvider();

            MaxSdkCallbacks.OnSdkInitializedEvent += LoadAds;
            
            UnityEngine.Debug.Log($"Initialize ad");
            
            MaxSdk.SetSdkKey(_settings.Ads.SdkKey);
            MaxSdk.InitializeSdk();
        }

        public void ShowInterstitial() => 
            _interstitialProvider.ShowInterstitial();

        public void ShowRewarded(string placement, Action onSuccess) => 
            _rewardedProvider.Show(onSuccess);

        public void LoadBanner() {}

        public void OnApplicationPause(bool pauseStatus) {}

        public void LoadRewarded() => _rewardedProvider.LoadAd();
        public void LoadInterstitial() => _interstitialProvider.LoadAd();

        public void Dispose() {}

        private void LoadAds(MaxSdkBase.SdkConfiguration configuration)
        {
            UnityEngine.Debug.Log($"Ads initialized - {configuration.IsSuccessfullyInitialized}");
            LoadInterstitial();
            LoadRewarded();
        }
    }
}