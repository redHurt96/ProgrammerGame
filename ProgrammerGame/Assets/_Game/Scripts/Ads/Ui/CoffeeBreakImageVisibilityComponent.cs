using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Ads.Ui
{
    public class CoffeeBreakImageVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Image[] _images;

        private IAdsService _ads;
        private AdsEvents _events;
        private AdsData _data;

        private void Start()
        {
            _ads = Services.Get<IAdsService>();
            _data = Services.Get<GameData>().Ads;
            _events = Services.Get<EventsMediator>().Ads;

            _events.OnCoffeeBreakActive += ActivateIfHasAds;
            _events.OnCoffeeBreakComplete += Hide;
            _events.RewardedReady += UpdateVisibility;

            ActivateIfHasAds();
        }

        private void OnDestroy()
        {
            if (_events != null)
            {
                _events.OnCoffeeBreakActive -= ActivateIfHasAds;
                _events.OnCoffeeBreakComplete -= Hide;
                _events.RewardedReady -= UpdateVisibility;
            }
        }

        private void Hide() => 
            SetImagesVisibility(false);

        private void ActivateIfHasAds() => 
            SetImagesVisibility(_ads.IsRewardedReady);

        private void UpdateVisibility(bool isVisible) => 
            SetImagesVisibility(isVisible && _data.CanShowCoffeeBreak);

        private void SetImagesVisibility(bool isVisible)
        {
            foreach (Image image in _images) 
                image.enabled = isVisible;
        }
    }
}