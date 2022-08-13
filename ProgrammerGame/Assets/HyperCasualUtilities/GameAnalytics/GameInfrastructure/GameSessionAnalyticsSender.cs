using UnityEngine;
using _Game.Common;
using _Game.Data;
using _Game.GameServices.Analytics;
using RH.Utilities.ServiceLocator;

namespace AP.Utilities.Analytics
{
    public class GameSessionAnalyticsSender : MonoBehaviour
    {
        private AnalyticsService _analyticsService;
        private EventsMediator _events;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _analyticsService = Services.Get<AnalyticsService>();
            
            _analyticsService.SendSessionStart("Start session");

            _events.LevelChanged += SendOnNewLevel;
            _events.OnUpgraded += SendOnBuyUpgrade;
            _events.ProgrammedPurchased += SendOnProgrammedPurchased;
            _events.ResetForBoostIntent += SendOnReset;
            
            _events.Ads.RewardedAdsShown += SendAdsEvent;
            _events.Ads.RewardedAdsStart += SendAdsEvent;
            _events.Ads.RewardedAvailabilityRequestForAnalytics.AddListener(SendAdsAvailabilityEvent);
        }

        private void OnDestroy()
        {
            _events.LevelChanged -= SendOnNewLevel;
            _events.OnUpgraded -= SendOnBuyUpgrade;
            _events.ProgrammedPurchased -= SendOnProgrammedPurchased;
            _events.ResetForBoostIntent -= SendOnReset;

            if (_events?.Ads != null)
            {
                _events.Ads.RewardedAdsShown -= SendAdsEvent;
                _events.Ads.RewardedAdsStart -= SendAdsEvent;
                _events.Ads.RewardedAvailabilityRequestForAnalytics.RemoveListener(SendAdsAvailabilityEvent);
            }
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                _analyticsService.SendSessionComplete("Pause");
        }

        private void OnApplicationQuit() => 
            _analyticsService.SendSessionComplete("Quit");

        private void SendOnReset(float f) => SendStats("Reset for boost");

        private void SendOnProgrammedPurchased() => SendStats("Programmer purchased");

        private void SendOnBuyUpgrade(UpgradeType arg1) => SendStats("Buy upgrade");

        private void SendOnNewLevel() => SendStats("New level");

        private void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result) => 
            _analyticsService.SendAdsEvent(eventType, adType, placement, result);

        private void SendStats(string eventName) => 
            _analyticsService.Send(eventName);

        private void SendAdsAvailabilityEvent(string placement, bool isAvailable) => 
            _analyticsService.SendAdsEvent(AdsEventType.video_ads_available, AdType.rewarded, placement, isAvailable.ToString());
    }
}