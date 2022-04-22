using _Game.Common;
using _Game.Configs;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Button))]
    public class ResetButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Update() =>
            _button.interactable = 
                _gameDataPresenter.BoostForProgress 
                * _gameData.PersistentData.MainBoost 
                - _gameData.PersistentData.MainBoost 
                > _settings.OpenResetThreshold;
    }
}