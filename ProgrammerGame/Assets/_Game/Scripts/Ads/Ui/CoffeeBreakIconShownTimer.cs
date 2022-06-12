using System.Collections;
using _Game.Common;
using _Game.Configs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Ads.Ui
{
    public class CoffeeBreakIconShownTimer : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        
        private AdsSettings _settings;
        private WaitForSeconds _showTime;
        private WaitForSeconds _hideTime;
        private AdsEvents _events;

        private void Start()
        {
            _settings = Services.Get<Settings>().Ads;
            _events = Services.Get<EventsMediator>().Ads;

            _showTime = new WaitForSeconds(_settings.CoffeeBreakIconShowTime);
            _hideTime = new WaitForSeconds(_settings.CoffeeBreakIconHideTime);

            _events.OnCoffeeBreakStart += BreakShowingCoroutine;
            _events.OnCoffeeBreakActive += StartShowingCoroutine;

            StartShowingCoroutine();
        }

        private void OnDestroy()
        {
            _events.OnCoffeeBreakStart -= BreakShowingCoroutine;
            _events.OnCoffeeBreakActive -= StartShowingCoroutine;
        }

        private void StartShowingCoroutine() => StartCoroutine(ShowWithInterval());
        private void BreakShowingCoroutine() => StopAllCoroutines();

        private IEnumerator ShowWithInterval()
        {
            while (Application.isPlaying)
            {
                _root.SetActive(true);

                yield return _showTime;

                _root.SetActive(false);

                yield return _hideTime;
            }
        }
    }
}