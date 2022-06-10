using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Ads
{
    public class UpperPanelAdsInteractor : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private AdsEventsService _adsEvents;

        private void Start()
        {
            _rectTransform = transform as RectTransform;
            _adsEvents = Services.Get<AdsEventsService>();

            _adsEvents.BannerLoaded += Shift;
        }

        private void OnDestroy() => 
            _adsEvents.BannerLoaded -= Shift;

        [ContextMenu("Shift")]
        private void Shift() => 
            _rectTransform.anchoredPosition += Vector2.down * 100f;
    }
}