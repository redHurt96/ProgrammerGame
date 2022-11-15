using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Common;
using _Game.GameServices.Analytics;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Debug.GameServices
{
    public class RewardedProvider
    {
        string adUnitId = "176c9c1f10c51d21";
        int retryAttempt;
        
        private AdsEvents _events;
        private List<Action> _onShownCallbacks;

        public RewardedProvider()
        {
            _events = Services.Get<EventsMediator>().Ads;
            
            MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
            MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
            MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
            MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
            MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
            MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
            MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
            MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
            
            LoadRewardedAd();
        }

        public void Show(Action onSuccess)
        {
            if (MaxSdk.IsRewardedAdReady(adUnitId))
            {
                _onShownCallbacks.Add(onSuccess);
                MaxSdk.ShowRewardedAd(adUnitId);
            }
        }

        private void LoadRewardedAd() => 
            MaxSdk.LoadRewardedAd(adUnitId);

        private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            retryAttempt = 0;
        }

        private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            UnityEngine.Debug.Log($"[ADS] {nameof(OnRewardedAdLoadFailedEvent)} with code {errorInfo.Code}");

            retryAttempt++;
            double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

            CoroutineLauncher.Start(LoadInterstitialDelayed((float) retryDelay));
        }

        private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) =>
            UnityEngine.Debug.Log($"[ADS] {nameof(OnRewardedAdDisplayedEvent)}");

        private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
        {
            _events.InvokeOnRewardedShown(AdsEventType.video_ads_watch, AdType.rewarded, adInfo.Placement, "fail");
            LoadRewardedAd();
            ClearAfterShown();
        }

        private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) =>
            UnityEngine.Debug.Log(
                $"[ADS] {nameof(OnRewardedAdClickedEvent)} with placement {adInfo.Placement}");

        private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            _events.InvokeOnRewardedStart(AdsEventType.video_ads_watch, AdType.rewarded, adInfo.Placement, "close");
            LoadRewardedAd();
        }

        private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
        {
            foreach (Action callback in _onShownCallbacks) 
                callback.Invoke();

            _events.InvokeOnRewardedShown(AdsEventType.video_ads_watch, AdType.rewarded, adInfo.Placement, "success");
            
            ClearAfterShown();
        }

        private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) {}

        private IEnumerator LoadInterstitialDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            LoadRewardedAd();
        }

        private void ClearAfterShown() => 
            _onShownCallbacks.Clear();
    }
}