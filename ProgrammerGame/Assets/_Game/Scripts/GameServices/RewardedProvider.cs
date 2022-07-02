using System;
using System.Collections.Generic;
using _Game.Common;
using RH.Utilities;
using RH.Utilities.ServiceLocator;

namespace _Game.GameServices
{
    public class RewardedProvider : IDisposable
    {
        private List<Action> _onShownCallbacks = new List<Action>();
        private CachedValue<bool> _isReady;

        private readonly AdsEvents _events;

        public RewardedProvider()
        {
            _events = Services.Get<EventsMediator>().Ads;
            
            IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
            IronSourceEvents.onRewardedVideoAdClickedEvent += RewardedVideoAdClickedEvent;
            IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
            IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
            IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
            IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
            IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
            IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;

            _isReady = CachedValue<bool>.Create(() => IronSource.Agent.isRewardedVideoAvailable());
        }

        public void Dispose()
        {
            IronSourceEvents.onRewardedVideoAdOpenedEvent -= RewardedVideoAdOpenedEvent;
            IronSourceEvents.onRewardedVideoAdClickedEvent -= RewardedVideoAdClickedEvent;
            IronSourceEvents.onRewardedVideoAdClosedEvent -= RewardedVideoAdClosedEvent;
            IronSourceEvents.onRewardedVideoAvailabilityChangedEvent -= RewardedVideoAvailabilityChangedEvent;
            IronSourceEvents.onRewardedVideoAdStartedEvent -= RewardedVideoAdStartedEvent;
            IronSourceEvents.onRewardedVideoAdEndedEvent -= RewardedVideoAdEndedEvent;
            IronSourceEvents.onRewardedVideoAdRewardedEvent -= RewardedVideoAdRewardedEvent;
            IronSourceEvents.onRewardedVideoAdShowFailedEvent -= RewardedVideoAdShowFailedEvent;
        }

        public void Load() => 
            IronSource.Agent.loadRewardedVideo();

        public bool IsReady => _isReady.Value;

        public void Show(Action onDone)
        {
            if (IsReady)
            {
                IronSource.Agent.showRewardedVideo();

                if (onDone != null)
                    _onShownCallbacks.Add(onDone);
            }
            else
            {
                UnityEngine.Debug.LogError($"Rewarded video not available");
            }
        }

        private void RewardedVideoAdOpenedEvent() =>
            UnityEngine.Debug.Log($"[ADS] {nameof(RewardedVideoAdOpenedEvent)}");

        private void RewardedVideoAdClickedEvent(IronSourcePlacement placement) =>
            UnityEngine.Debug.Log(
                $"[ADS] {nameof(RewardedVideoAdClickedEvent)} with placement {placement.getPlacementName()}");

        private void RewardedVideoAdClosedEvent() =>
            UnityEngine.Debug.Log($"[ADS] {nameof(RewardedVideoAdClosedEvent)}");

        private void RewardedVideoAvailabilityChangedEvent(bool availability)
        {
            UnityEngine.Debug.Log($"[ADS] {nameof(RewardedVideoAvailabilityChangedEvent)} - {availability}");
            
            _events.InvokeRewardedReadyEvent(availability);
        }

        private void RewardedVideoAdStartedEvent() =>
            UnityEngine.Debug.Log($"[ADS] {nameof(RewardedVideoAdStartedEvent)}");

        private void RewardedVideoAdEndedEvent() =>
            UnityEngine.Debug.Log($"[ADS] {nameof(RewardedVideoAdEndedEvent)}");

        private void RewardedVideoAdRewardedEvent(IronSourcePlacement placement)
        {
            UnityEngine.Debug.Log(
                $"[ADS] {nameof(RewardedVideoAdRewardedEvent)} with placement {placement.getPlacementName()}");

            foreach (Action callback in _onShownCallbacks) 
                callback.Invoke();

            _onShownCallbacks.Clear();

            _events.InvokeOnRewardedShown();
        }

        private void RewardedVideoAdShowFailedEvent(IronSourceError error)
        {
            UnityEngine.Debug.Log(
                $"[ADS] {nameof(RewardedVideoAdRewardedEvent)} with placement {error.getCode()} - {error.getDescription()}");

            _onShownCallbacks.Clear();
        }
    }
}