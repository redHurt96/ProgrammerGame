using _Game.Configs;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Image))]
    public class ResetButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Update()
        {
            bool enabled = GameData.Instance.BoostForProgress()
                               * GameData.Instance.PersistentData.MainBoost
                               - GameData.Instance.PersistentData.MainBoost
                               > Settings.Instance.OpenResetThreshold;

            _canvasGroup.alpha = enabled ? 1f : 0f;
            _canvasGroup.blocksRaycasts = enabled;
        }
    }
}