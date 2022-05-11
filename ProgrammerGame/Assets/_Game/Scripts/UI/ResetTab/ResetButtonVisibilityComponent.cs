using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Button))]
    public class ResetButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private GameDataPresenter _gameDataPresenter;

        private void Start() => 
            _gameDataPresenter = Services.Get<GameDataPresenter>();

        private void Update() =>
            _button.interactable = 
                _gameDataPresenter.BoostForProgress 
                * GameData.Instance.PersistentData.MainBoost 
                - GameData.Instance.PersistentData.MainBoost 
                > Settings.Instance.OpenResetThreshold;
    }
}