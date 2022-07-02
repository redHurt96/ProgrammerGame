using _Game.Common;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.LevelPanel
{
    public class LevelProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;

        private EventsMediator _eventsMediator;
        private GameData _data;

        private void Start()
        {
            _eventsMediator = Services.Get<EventsMediator>();
            _data = Services.Get<GameData>();

            _eventsMediator.MoneyCountChanged += UpdateProgressBar;
        }

        private void OnDestroy()
        {
            if (_eventsMediator != null)
                _eventsMediator.MoneyCountChanged -= UpdateProgressBar;
        }

        private void UpdateProgressBar(double obj) => 
            _fill.fillAmount = _data.ReachNewLevelProgress();
    }
}