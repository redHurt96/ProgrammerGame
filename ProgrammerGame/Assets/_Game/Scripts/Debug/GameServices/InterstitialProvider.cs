using System;
using System.Collections;
using _Game.Common;
using _Game.GameServices.Analytics;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Debug.GameServices
{
    public class InterstitialProvider
    {
        private const string adUnitId = "641fda6833ef61b0";

        public bool IsReady => MaxSdk.IsInterstitialReady(adUnitId);
        
        private int retryAttempt;
        
        private readonly AdsEvents _events;

        public InterstitialProvider()
        {
            _events = Services.Get<EventsMediator>().Ads;
            
            // Attach callback
            MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
            MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
            MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
            MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
            MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
            MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;
        }

        public void LoadAd()
        {
            UnityEngine.Debug.Log($"Load interstitial ad");
            MaxSdk.LoadInterstitial(adUnitId);
        }

        private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            UnityEngine.Debug.Log("[ADS] " + nameof(OnInterstitialLoadedEvent));
            retryAttempt = 0;
        }

        private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            UnityEngine.Debug.Log($"[ADS] {nameof(OnInterstitialLoadFailedEvent)} with code {errorInfo.Code}");
            
            retryAttempt++;
            double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

            CoroutineLauncher.Start(LoadInterstitialDelayed((float)retryDelay));
        }

        private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) =>
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_started, AdType.interstitial, "main", "start");

        private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
        {
            UnityEngine.Debug.Log($"[ADS] {nameof(OnInterstitialAdFailedToDisplayEvent)} with code {errorInfo.Code}");
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_watch, AdType.interstitial, "main", "fail");
            
            LoadAd();
        }

        private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) =>
            UnityEngine.Debug.Log(nameof(OnInterstitialClickedEvent));

        private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_started, AdType.interstitial, "main", "close");
            LoadAd();
        }

        public void ShowInterstitial()
        {
            if (IsReady)
                MaxSdk.ShowInterstitial(adUnitId);
            else
                UnityEngine.Debug.LogError("[ADS] Interstitial doesn't ready");
        }

        private IEnumerator LoadInterstitialDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            LoadAd();
        }
    }
}