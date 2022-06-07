using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Ads
{
    public class CoffeeBreakImageVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private AdsService _ads;
        private AdsEventsService _events;
        private AdsData _data;

        private void Start()
        {
            _ads = Services.Get<AdsService>();
            _data = Services.Get<GameData>().Ads;
            _events = Services.Get<AdsEventsService>();

            _events.OnCoffeeBreakActive += ActivateIfHasAds;
            _events.OnCoffeeBreakComplete += Hide;
            _events.RewardedReady += UpdateVisibility;

            ActivateIfHasAds();
        }

        private void OnDestroy()
        {
            _events.OnCoffeeBreakActive -= ActivateIfHasAds;
            _events.OnCoffeeBreakComplete -= Hide;
            _events.RewardedReady -= UpdateVisibility;
        }

        private void Hide() => 
            _image.enabled = false;

        private void ActivateIfHasAds() => 
            _image.enabled = _ads.IsRewardedReady;

        private void UpdateVisibility(bool isVisible) => 
            _image.enabled = isVisible && _data.CanShowCoffeeBreak;
    }
}