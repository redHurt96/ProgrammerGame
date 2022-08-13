using _Game.Common;
using _Game.GameServices.Analytics;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public class InterstitialProvider
    {
        private readonly AdsEvents _events;

        public InterstitialProvider()
        {
            _events = Services.Get<EventsMediator>().Ads;
            
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

        public void Load()
        {
            UnityEngine.Debug.Log("[ADS] Load interstitial");
            IronSource.Agent.loadInterstitial();
        }

        public void Show()
        {
            if (IronSource.Agent.isInterstitialReady())
                IronSource.Agent.showInterstitial();
            else
                UnityEngine.Debug.LogError("[ADS] Interstitial doesn't ready");
        }
            
        private void InterstitialAdShowFailedEvent(IronSourceError error)
        {
            UnityEngine.Debug.Log($"[ADS] {nameof(InterstitialAdShowFailedEvent)} with code {error.getCode()}");
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_watch, AdType.interstitial, "main", "fail");
        }

        private void InterstitialAdClickedEvent() => 
            UnityEngine.Debug.Log(nameof(InterstitialAdClickedEvent));

        public void InterstitialAdOpenedEvent()
        {
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdOpenedEvent));
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_started, AdType.interstitial, "main", "start");
        }

        private void InterstitialAdClosedEvent()
        {
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdClosedEvent));
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_started, AdType.interstitial, "main", "close");
        }

        private void InterstitialAdShowSucceededEvent()
        {
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdShowSucceededEvent));
            _events.InvokeOnInterstitialShown(AdsEventType.video_ads_watch, AdType.interstitial, "main", "success");
        }

        private void InterstitialAdLoadFailedEvent(IronSourceError error) => 
            UnityEngine.Debug.Log($"[ADS] {nameof(InterstitialAdLoadFailedEvent)} with code {error.getCode()}");

        private void InterstitialAdReadyEvent() => 
            UnityEngine.Debug.Log("[ADS] " + nameof(InterstitialAdReadyEvent));
    }
}