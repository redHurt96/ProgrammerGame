using System;
using _Game.Common;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;

namespace _Game.Debug.GameServices
{
    public class AdsMocService : IAdsService
    {
        private readonly AdsEvents _adsEvents;

        public AdsMocService() => 
            _adsEvents = Services.Get<EventsMediator>().Ads;

        public bool IsInterstitialReady => AdsMocSettings.IsInterstitialReady;
        public bool IsRewardedReady => AdsMocSettings.IsRewardedReady;

        public void LoadInterstitial() => 
            UnityEngine.Debug.Log($"[ADS_MOC] - Interstitial load");

        public void ShowInterstitial()
        {
            if (IsInterstitialReady)
                UnityEngine.Debug.Log($"[ADS_MOC] - Interstitial shown");
            else
                UnityEngine.Debug.LogError($"[ADS_MOC] - Interstitial not ready");
        }

        public void LoadRewarded() =>
            UnityEngine.Debug.Log($"[ADS_MOC] - Rewarded load");

        public void ShowRewarded(string placement, Action onSuccess)
        {
            if (IsRewardedReady)
            {
                UnityEngine.Debug.Log($"[ADS_MOC] - Rewarded shown");
                onSuccess?.Invoke();
            }
            else
            {
                UnityEngine.Debug.LogError($"[ADS_MOC] - Rewarded not ready");
            }
        }

        public bool IsBannerShown => AdsMocSettings.IsBannerShown;

        public void LoadBanner()
        {
            UnityEngine.Debug.Log("Load banner");
            _adsEvents.InvokeBannerLoadedEvent();
        }
    }
}