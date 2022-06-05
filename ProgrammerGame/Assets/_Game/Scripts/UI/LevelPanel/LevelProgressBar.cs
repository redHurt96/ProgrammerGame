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

        private GlobalEvents _events;
        private GameData _data;

        private void Start()
        {
            _events = Services.Get<GlobalEvents>();
            _data = Services.Get<GameData>();

            _events.MoneyCountChanged += UpdateProgressBar;
        }

        private void OnDestroy() => 
            _events.MoneyCountChanged -= UpdateProgressBar;

        private void UpdateProgressBar(double obj) => 
            _fill.fillAmount = _data.ReachNewLevelProgress();
    }
}