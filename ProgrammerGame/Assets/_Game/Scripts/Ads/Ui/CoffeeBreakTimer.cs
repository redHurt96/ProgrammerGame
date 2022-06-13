using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Ads.Ui
{
    public class CoffeeBreakTimer : MonoBehaviour
    {
        [SerializeField] private Text _label;
        private AdsEvents _events;

        private void Start()
        {
            _events = Services.Get<EventsMediator>().Ads;

            _events.OnCoffeeBreakStart += ShowLabel;
            _events.OnCoffeeBreakTimerUpdated += UpdateLabel;
            _events.OnCoffeeBreakComplete += HideLabel;

            HideLabel();
        }

        private void OnDestroy()
        {
            _events.OnCoffeeBreakStart -= ShowLabel;
            _events.OnCoffeeBreakTimerUpdated -= UpdateLabel;
            _events.OnCoffeeBreakComplete -= HideLabel;
        }

        private void UpdateLabel(float time) => 
            _label.text = $"{(int) time / 60:D2}:{(int) time % 60:D2}";

        private void HideLabel() => gameObject.SetActive(false);
        private void ShowLabel() => gameObject.SetActive(true);
    }
}