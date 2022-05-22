using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class BaseWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundCloseButton;

        private WindowsManager _windowsManager;

        private void Awake()
        {
            _windowsManager = Services.Get<WindowsManager>();

            if (_closeButton != null)
                _closeButton.onClick.AddListener(Close);
            
            if (_backgroundCloseButton != null)
                _backgroundCloseButton.onClick.AddListener(Close);
        }

        protected void Close()
        {
            _windowsManager.Hide(this);
        }

        protected virtual void PerformBeforeOpen() {}
        protected virtual void PerformBeforeClose() {}

        public void Show(WindowsManager windowsManager)
        {
            PerformBeforeOpen();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            PerformBeforeClose();
            gameObject.SetActive(false);
        }
    }
}