using System;
using _Game.GameServices;

namespace _Game.Debug.GameServices
{
    public class ApplovinAdsService : IAdsService
    {
        public bool IsInterstitialReady { get; }
        public bool IsRewardedReady { get; }
        public bool IsBannerShown { get; }
        
        private readonly InterstitialProvider _interstitialProvider;
        private readonly RewardedProvider _rewardedProvider;

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
            throw new NotImplementedException();
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }
    }
}