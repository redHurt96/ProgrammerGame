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

        private bool CanBeVisible => _visibilityCondition != null && _visibilityCondition.Invoke();

        private void OnDestroy()
        {
            _events.MoneyCountChanged -= UpdateFromMoneys;
            _events.Ads.RewardedReady -= UpdateButtonFromAdsAvailability;
        }

        public void Setup(Func<bool> visibilityCondition, Action onAdvComplete)
        {
            _ads ??= Services.Get<IAdsService>();
            _events ??= Services.Get<EventsMediator>();

            _events.MoneyCountChanged += UpdateFromMoneys;
            _events.Ads.RewardedReady += UpdateButtonFromAdsAvailability;

            _visibilityCondition = visibilityCondition;
            _onAdvComplete = onAdvComplete;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(ShowAd);

            UpdateButtonVisibility();
        }

        private void UpdateButtonFromAdsAvailability(bool adsAvailability) => 
            UpdateButtonVisibility();

        private void UpdateFromMoneys(double amount) => 
            UpdateButtonVisibility();

        private void UpdateButtonVisibility() =>
            _button.gameObject.SetActive(CanBeVisible && _ads.IsRewardedReady);

        private void ShowAd() => 
            _ads.ShowRewarded("Project", AddLevel);

        private void AddLevel() => 
            _onAdvComplete.Invoke();
    }
}