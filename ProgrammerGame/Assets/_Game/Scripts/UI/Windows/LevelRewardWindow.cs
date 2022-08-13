using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using _Game.Scripts.Exception;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class LevelRewardWindow : BaseWindow
    {
        [SerializeField] private Text _reward;
        [SerializeField] private Button _adsIncreaseRewardButton;

        private IAdsService _ads;
        private AdsEvents _adsEvents;

        protected override void PerformBeforeOpen()
        {
            _ads ??= Services.Get<IAdsService>();
            _adsEvents ??= Services.Get<EventsMediator>().Ads;
            _windowsManager ??= Services.Get<WindowsManager>();

            _reward.text = GameData.Instance.GetRewardForLevel().ToPriceString();

            PrepareAdsButton();
        }

        private void PrepareAdsButton()
        {
            bool isRewardedReady = _ads.IsRewardedReady;

            _adsIncreaseRewardButton.interactable = isRewardedReady;
            
            _adsEvents.RewardedAvailabilityRequestForAnalytics?.Invoke("Show reward for level - LevelRewardWindow", isRewardedReady);

            if (isRewardedReady)
                _adsIncreaseRewardButton.onClick.AddListener(DoubleReward);
            else
                _adsEvents.RewardedReady += EnableButton;
        }

        private void EnableButton(bool adsAvailability)
        {
            if (adsAvailability)
            {
                _adsEvents.RewardedReady -= EnableButton;
                _adsIncreaseRewardButton.interactable = _ads.IsRewardedReady;
            }
        }

        private void DoubleReward()
        {
            _adsIncreaseRewardButton.onClick.RemoveListener(DoubleReward);
            UnityEngine.Debug.Log("Show reward for level - LevelRewardWindow");
            _adsEvents.IntentRewardForLevel();

            _windowsManager.Hide(this);
        }
    }
}