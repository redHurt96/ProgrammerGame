using _Game.Common;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Ads
{
    public class CoffeeBreakTimer : MonoBehaviour
    {
        [SerializeField] private Text _label;
        private AdsEventsService _events;

        private void Start()
        {
            _events = Services.Get<AdsEventsService>();

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
            _label.text = $"0{(int) time / 60}:{(int) time % 60}";

        private void HideLabel() => _label.enabled = false;
        private void ShowLabel() => _label.enabled = true;
    }
}