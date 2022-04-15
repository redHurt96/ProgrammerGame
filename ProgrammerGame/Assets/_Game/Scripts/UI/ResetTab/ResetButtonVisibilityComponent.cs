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
                GameDataPresenter.Instance.BoostForProgress - GameData.Instance.MainBoost > Settings.Instance.OpenResetThreshold;
    }
}