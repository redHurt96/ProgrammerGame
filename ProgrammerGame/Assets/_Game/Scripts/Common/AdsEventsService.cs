using System;
using RH.Utilities.ServiceLocator;

namespace _Game.Common
{
    public class AdsEventsService : IService
    {
        public event Action RewardedAdsShown;
        public event Action OnCoffeeBreakIntent;
        public event Action OnRewardForLevelIntent;
        public event Action<float> OnCoffeeBreakTimerUpdated;
        public event Action OnCoffeeBreakComplete;
        public event Action OnCoffeeBreakStart;

        public void InvokeOnRewardedAdsShown() => RewardedAdsShown?.Invoke();
        public void CoffeeBreakIntent() => OnCoffeeBreakIntent?.Invoke();
        public void IntentRewardForLevel() => OnRewardForLevelIntent?.Invoke();
        public void CoffeeBreakTimeUpdate(float left) => OnCoffeeBreakTimerUpdated?.Invoke(left);
        public void CompleteCoffeeBreak() => OnCoffeeBreakComplete?.Invoke();
        public void StartCoffeeBreak() => OnCoffeeBreakStart?.Invoke();
    }
}