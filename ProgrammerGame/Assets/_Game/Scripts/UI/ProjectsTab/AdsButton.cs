using System;
using _Game.Common;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    public class AdsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IAdsService _ads;
        private EventsMediator _events;

        private Func<bool> _visibilityCondition;
        private Action _onAdvComplete;
        private Func<string> _adsPlacement;

        private bool CanBeVisible => _visibilityCondition != null && _visibilityCondition.Invoke();

        public void Setup(Func<bool> visibilityCondition, Action onAdvComplete, Func<string> placement)
        {
            _ads ??= Services.Get<IAdsService>();
            _events ??= Services.Get<EventsMediator>();

            _adsPlacement = placement;
            _events.MoneyCountChanged += UpdateFromMoneys;
            _events.Ads.RewardedReady += UpdateButtonFromAdsAvailability;

            _visibilityCondition = visibilityCondition;
            _onAdvComplete = onAdvComplete;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(ShowAd);

            UpdateButtonVisibility();
        }

        private void OnDestroy()
        {
            if (_events?.Ads != null)
            {
                _events.MoneyCountChanged -= UpdateFromMoneys;
                _events.Ads.RewardedReady -= UpdateButtonFromAdsAvailability;
            }
        }

        private void UpdateButtonFromAdsAvailability(bool adsAvailability) => 
            UpdateButtonVisibility();

        private void UpdateFromMoneys(double amount) => 
            UpdateButtonVisibility();

        private void UpdateButtonVisibility() =>
            _button.gameObject.SetActive(CanBeVisible && _ads.IsRewardedReady);

        private void ShowAd() => 
            _ads.ShowRewarded(_adsPlacement.Invoke(), AddLevel);

        private void AddLevel() => 
            _onAdvComplete.Invoke();
    }
}