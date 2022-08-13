using System;
using _Game.GameServices.Analytics;
using UnityEngine.Events;

namespace _Game.Common
{
    public class AdsEvents
    {
        public UnityEvent<string, bool> RewardedAvailabilityRequestForAnalytics = new UnityEvent<string, bool>();
        
        public event Action<AdsEventType, AdType, string, string> RewardedAdsShown;
        public event Action<AdsEventType, AdType, string, string> RewardedAdsStart;
        public event Action<bool> RewardedReady;
        public event Action OnCoffeeBreakIntent;
        public event Action OnRewardForLevelIntent;
        public event Action<float> OnCoffeeBreakTimerUpdated;
        public event Action OnCoffeeBreakComplete;
        public event Action OnCoffeeBreakStart;
        public event Action OnCoffeeBreakActive;
        public event Action BannerLoaded;
        public event Action<AdsEventType, AdType, string, string> InterstitialShown;

        public void InvokeOnRewardedShown(AdsEventType eventType, AdType type, string placement, string result) => 
            RewardedAdsShown?.Invoke(eventType, type, placement, result);
        public void InvokeOnRewardedStart(AdsEventType eventType, AdType type, string placement, string result) => 
            RewardedAdsStart?.Invoke(eventType, type, placement, result);
        public void CoffeeBreakIntent() => OnCoffeeBreakIntent?.Invoke();
        public void IntentRewardForLevel() => OnRewardForLevelIntent?.Invoke();
        public void CoffeeBreakTimeUpdate(float left) => OnCoffeeBreakTimerUpdated?.Invoke(left);
        public void CompleteCoffeeBreak() => OnCoffeeBreakComplete?.Invoke();
        public void StartCoffeeBreak() => OnCoffeeBreakStart?.Invoke();
        public void InvokeRewardedReadyEvent(bool availability) => RewardedReady?.Invoke(availability);
        public void ReloadCoffeeBreak() => OnCoffeeBreakActive?.Invoke();

        public void InvokeBannerLoadedEvent() => BannerLoaded?.Invoke();

        public void InvokeOnInterstitialShown(AdsEventType eventType, AdType type, string placement, string result) => 
            InterstitialShown?.Invoke(eventType, type, placement, result);
    }
}