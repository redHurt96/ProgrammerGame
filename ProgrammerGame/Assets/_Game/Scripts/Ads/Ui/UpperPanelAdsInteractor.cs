using _Game.Common;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Ads.Ui
{
    public class UpperPanelAdsInteractor : MonoBehaviour
    {
        private const float SHIFT_SIZE = 100f;
        
        private RectTransform _rectTransform;
        private AdsEvents _events;
        private IAdsService _ads;

        private void Start()
        {
            _rectTransform = transform as RectTransform;
            
            _events = Services.Get<EventsMediator>().Ads;
            _ads = Services.Get<IAdsService>();

            if (_ads.IsBannerShown)
                Shift();
            
            _events.BannerLoaded += Shift;
        }

        private void OnDestroy() => 
            _events.BannerLoaded -= Shift;

        private void Shift()
        {
            if (Mathf.Abs(_rectTransform.anchoredPosition.y) < SHIFT_SIZE)
                _rectTransform.anchoredPosition += Vector2.down * SHIFT_SIZE;
        }
    }
}