using System;
using _Game.Debug.GameServices;

namespace _Game.GameServices
{
    public class ApplovinAdsService : IAdsService
    {
        public bool IsInterstitialReady => MaxSdk.IsInterstitialReady(adUnitId);
        public bool IsRewardedReady => MaxSdk.IsInterstitialReady(adUnitId);
        public bool IsBannerShown => false;

        private readonly InterstitialProvider _interstitialProvider;
        private readonly RewardedProvider _rewardedProvider;
        
        private string adUnitId;

        public ApplovinAdsService()
        {
            _interstitialProvider = new InterstitialProvider();
            _rewardedProvider = new RewardedProvider();
        }

        public void ShowInterstitial() => 
            _interstitialProvider.ShowInterstitial();

        public void ShowRewarded(string placement, Action onSuccess) => 
            _rewardedProvider.Show(onSuccess);

        public void LoadBanner()
        {
            
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}