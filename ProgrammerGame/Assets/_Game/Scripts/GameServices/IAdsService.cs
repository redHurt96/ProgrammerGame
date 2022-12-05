using System;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public interface IAdsService : IService, IDisposable
    {
        bool IsInterstitialReady { get; }
        bool IsRewardedReady { get; }
        void ShowInterstitial();
        void ShowRewarded(string placement, Action onSuccess);
        bool IsBannerShown { get; }
        void LoadBanner();
        void OnApplicationPause(bool pauseStatus);
        void LoadRewarded();
        void LoadInterstitial();
    }
}