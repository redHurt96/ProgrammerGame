using _Game.Configs;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Image))]
    public class ResetButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void Update() =>
            _image.enabled = 
                GameData.Instance.BoostForProgress() 
                * GameData.Instance.PersistentData.MainBoost 
                - GameData.Instance.PersistentData.MainBoost 
                > Settings.Instance.OpenResetThreshold;
    }
}