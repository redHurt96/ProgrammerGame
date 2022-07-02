using System;
using _Game.Common;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    internal class BannerProvider : IDisposable
    {
        private readonly EventsMediator _eventsMediator;
        
        public bool IsShown { get; private set; }

        public BannerProvider()
        {
            _eventsMediator = Services.Get<EventsMediator>();
            
            IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
            IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;        
            IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent; 
            IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent; 
            IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
            IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;
        }

        public void Dispose()
        {
            IronSourceEvents.onBannerAdLoadedEvent -= BannerAdLoadedEvent;
            IronSourceEvents.onBannerAdLoadFailedEvent -= BannerAdLoadFailedEvent;        
            IronSourceEvents.onBannerAdClickedEvent -= BannerAdClickedEvent; 
            IronSourceEvents.onBannerAdScreenPresentedEvent -= BannerAdScreenPresentedEvent; 
            IronSourceEvents.onBannerAdScreenDismissedEvent -= BannerAdScreenDismissedEvent;
            IronSourceEvents.onBannerAdLeftApplicationEvent -= BannerAdLeftApplicationEvent;
        }

        public void Load()
        {
            UnityEngine.Debug.Log($"[ADS] Load banner");
            IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.TOP);
        }

        private void BannerAdLoadedEvent()
        {
            UnityEngine.Debug.Log($"[ADS] {nameof(BannerAdLoadedEvent)}");
            _eventsMediator.Ads.InvokeBannerLoadedEvent();
            IsShown = true;
        }

        private void BannerAdLoadFailedEvent(IronSourceError error) => 
            UnityEngine.Debug.LogError($"[ADS] {nameof(BannerAdLoadFailedEvent)} {error.getCode()} {error.getDescription()}");

        private void BannerAdClickedEvent() => 
            UnityEngine.Debug.Log($"[ADS] {nameof(BannerAdClickedEvent)}");

        private void BannerAdScreenPresentedEvent() => 
            UnityEngine.Debug.Log($"[ADS] {nameof(BannerAdScreenPresentedEvent)}");

        private void BannerAdScreenDismissedEvent() => 
            UnityEngine.Debug.Log($"[ADS] {nameof(BannerAdScreenDismissedEvent)}");

        private void BannerAdLeftApplicationEvent() => 
            UnityEngine.Debug.Log($"[ADS] {nameof(BannerAdLeftApplicationEvent)}");
    }
}