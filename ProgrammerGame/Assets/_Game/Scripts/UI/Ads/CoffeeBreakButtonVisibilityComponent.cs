using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Ads
{
    public class CoffeeBreakButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private AdsService _ads;
        private AdsEventsService _events;
        private AdsData _data;

        private void Start()
        {
            _data = Services.Get<GameData>().Ads;
            _ads = Services.Get<AdsService>();
            _events = Services.Get<AdsEventsService>();

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