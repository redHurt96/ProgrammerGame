using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;
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
                GameData.Instance.BoostForProgress 
                * GameData.Instance.PersistentData.MainBoost 
                - GameData.Instance.PersistentData.MainBoost 
                > Settings.Instance.OpenResetThreshold;
    }
    
    public class OpenResetWindowButton : BaseActionButton
    {
        private WindowsManager _windowsManager;

        protected override void PerformOnStart()
        {
            _windowsManager = Services.Get<WindowsManager>();
        }

        protected override void PerformOnClick()
        {
            _windowsManager.Show(SceneObjects.Instance.ResetWindow);
        }
    }
}