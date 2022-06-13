using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Ads.Ui
{
    public class CoffeeBreakButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IAdsService _ads;
        private AdsEvents _events;
        private AdsData _data;

        private void Start()
        {
            _data = Services.Get<GameData>().Ads;
            _ads = Services.Get<IAdsService>();
            _events = Services.Get<EventsMediator>().Ads;

            _events.RewardedReady += EnableButtonIfCoffeeBreakReady;
            _events.OnCoffeeBreakActive += ShowIfHasAds;
            _events.OnCoffeeBreakStart += DisableButton;

            ShowIfHasAds();
        }

        private void ShowIfHasAds() => 
            _button.interactable = _ads.IsRewardedReady;

        private void DisableButton() => 
            _button.interactable = false;

        private void EnableButtonIfCoffeeBreakReady(bool adsAvailability) => 
            _button.interactable = adsAvailability && _data.CanShowCoffeeBreak;
    }
}