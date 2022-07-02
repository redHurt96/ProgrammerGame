using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.UI.ProjectsTab;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Ads.Ui
{
    public class ResetTab : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AdsButton _adsButton;
        
        private GameData _data;
        private EventsMediator _events;
        private Settings _settings;

        private bool _canReset => _data.CanReset();

        private void OnEnable()
        {
            _data ??= Services.Get<GameData>();
            _events ??= Services.Get<EventsMediator>();
            _settings ??= Services.Get<Settings>();
            
            _button.interactable = _canReset;
        }

        private void Start()
        {
            _button.onClick.AddListener(ResetForBoost);
            _adsButton.Setup(
                () => _canReset, 
                ResetForBoostDouble, 
                () => $"Show ad for additional boost");
        }

        private void ResetForBoost()
        {
            float boost = _data.BoostForProgress();
            _events.ResetForBoost(boost);
        }

        private void ResetForBoostDouble()
        {
            float boost = _data.BoostForProgress() * _settings.Ads.ResetBoost;
            _events.ResetForBoost(boost);
        }
    }
}