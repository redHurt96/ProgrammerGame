using _Game.Common;
using _Game.GameServices;
using _Game.Scripts.Exception;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class EarnedWhileAwayWindow : BaseWindow
    {
        [SerializeField] private Text _countTitle;
        [SerializeField] private Button _adsButton;

        private double _countValue;

        private IAdsService _ads;
        private EventsMediator _events;

        protected override void PerformBeforeOpen()
        {
            _ads ??= Services.Get<IAdsService>();
            _events ??= Services.Get<EventsMediator>();

            if (!_ads.IsRewardedReady) 
                _adsButton.interactable = false;

            _adsButton.onClick.AddListener(DoubleReward);
            _events.Ads.RewardedReady += ShowButton;
        }

        private void DoubleReward()
        {
            _ads.ShowRewarded("Idle income", () =>
            {
                _events.IntentToChangeMoney(_countValue);
                _windowsManager.Hide(this);
            });
        }

        private void ShowButton(bool availability) => 
            _adsButton.interactable = availability;

        public void SetCount(double count)
        {
            _countValue = count;

            _countTitle.text = count.ToPriceString();
        }

        protected override void PerformBeforeClose()
        {
            _events.IntentToChangeMoney(_countValue);
            _events.Ads.RewardedReady -= ShowButton;
            _adsButton.onClick.RemoveListener(DoubleReward);
            _countValue = 0;
        }
    }
}
