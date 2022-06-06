using System;
using System.Collections.Generic;

namespace _Game.GameServices
{
    public class InterstitialProvider : IAdTypeProvider
    {
        private List<Action> _onAdLoadedCallbacks = new List<Action>();

        public InterstitialProvider()
        {
            IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
            IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;        
            IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent; 
            IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailedEvent; 
            IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
            IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
            IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
        }

        public void Dispose()
        {
            IronSourceEvents.onInterstitialAdReadyEvent -= InterstitialAdReadyEvent;
            IronSourceEvents.onInterstitialAdLoadFailedEvent -= InterstitialAdLoadFailedEvent;        
            IronSourceEvents.onInterstitialAdShowSucceededEvent -= InterstitialAdShowSucceededEvent; 
            IronSourceEvents.onInterstitialAdShowFailedEvent -= InterstitialAdShowFailedEvent; 
            IronSourceEvents.onInterstitialAdClickedEvent -= InterstitialAdClickedEvent;
            IronSourceEvents.onInterstitialAdOpenedEvent -= InterstitialAdOpenedEvent;
            IronSourceEvents.onInterstitialAdClosedEvent -= InterstitialAdClosedEvent;
        }

        public bool IsReady => 
            IronSource.Agent.isInterstitialReady();

        public void Load(Action onLoaded = null)
        {
            UnityEngine.Debug.Log("[ADS] Load interstitial");
            IronSource.Agent.loadInterstitial();

            if (onLoaded != null)
                _onAdLoadedCallbacks.Add(onLoaded);
        }

        public void Show()
        {
            if (IronSource.Agent.isInterstitialReady())
                IronSource.Agent.showInterstitial();
            else
                UnityEngine.Debug.LogError("[ADS] Interstitial doesn't ready");
        }
            
        private void InterstitialAdShowFailedEvent(IronSourceError error) => 
            UnityEngine.Debug.Log($"[ADS] {nameof(InterstitialAdShowFailedEvent)} with code {error.getCode()}");

        private void InterstitialAdClickedEvent() => 
            UnityEngine.Debug.Log(nameof(InterstitialAdClickedEvent));

        public void InterstitialAdOpenedEvent() => 
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdOpenedEvent));

        private void InterstitialAdClosedEvent() => 
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdClosedEvent));

        private void InterstitialAdShowSucceededEvent() => 
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdShowSucceededEvent));

        private void InterstitialAdLoadFailedEvent(IronSourceError error) => 
            UnityEngine.Debug.Log($"[ADS] {nameof(InterstitialAdLoadFailedEvent)} with code {error.getCode()}");

        private void InterstitialAdReadyEvent()
        {
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdReadyEvent));

            foreach (Action callback in _onAdLoadedCallbacks) 
                callback?.Invoke();

            _onAdLoadedCallbacks.Clear();
        }
    }
}