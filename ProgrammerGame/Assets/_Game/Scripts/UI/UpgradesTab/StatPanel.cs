using _Game.Common;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public abstract class StatPanel : MonoBehaviour
    {
        protected abstract float Value { get; }
        protected GameData _data;

        [SerializeField] private Text _valueText;

        private EventsMediator _events;

        private void Start()
        {
            _events = Services.Get<EventsMediator>();
            _data = Services.Get<GameData>();

            UpdateValue(UpgradeType.Interior);

            _events.OnUpgraded += UpdateValue;
        }

        private void OnDestroy() => 
            _events.OnUpgraded -= UpdateValue;

        private void UpdateValue(UpgradeType obj) => 
            _valueText.text = $"+{Value * 100}%";
    }
}
