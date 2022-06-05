using System;
using RH.Utilities.ServiceLocator;

namespace _Game.Common
{
    public class AdsEventsService : IService
    {
        public event Action RewardedAdsShown;
        public event Action OnCoffeeBreakIntent;
        public event Action OnRewardForLevelIntent;

        public void InvokeOnRewardedAdsShown() => RewardedAdsShown?.Invoke();
        public void CoffeeBreakIntent() => OnCoffeeBreakIntent?.Invoke();
        public void IntentRewardForLevel() => OnRewardForLevelIntent?.Invoke();
    }
}