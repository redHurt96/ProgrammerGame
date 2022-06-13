using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Ads.Ui
{
    public class UpperPanelAdsInteractor : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private AdsEvents _events;

        private void Start()
        {
            _rectTransform = transform as RectTransform;
            _events = Services.Get<EventsMediator>().Ads;

            _events.BannerLoaded += Shift;
        }

        private void OnDestroy() => 
            _events.BannerLoaded -= Shift;

        private void Shift() => 
            _rectTransform.anchoredPosition += Vector2.down * 100f;
    }
}