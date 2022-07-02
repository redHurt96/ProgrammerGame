using System;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public interface IAdsService : IService
    {
        bool IsInterstitialReady { get; }
        bool IsRewardedReady { get; }
        void LoadInterstitial();
        void ShowInterstitial();
        void LoadRewarded();
        void ShowRewarded(string placement, Action onSuccess);
        bool IsBannerShown { get; }
        void LoadBanner();
    }
}