using _Game.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class BaseWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundCloseButton;

        private void Awake()
        {
            if (_closeButton != null)
                _closeButton.onClick.AddListener(Close);
            
            if (_backgroundCloseButton != null)
                _backgroundCloseButton.onClick.AddListener(Close);
        }

        protected void Close()
        {
            PerformBeforeClose();
            WindowsManager.Hide(this);
        }

        protected virtual void PerformBeforeOpen() {}
        protected virtual void PerformBeforeClose() {}

        public void Show()
        {
            PerformBeforeOpen();
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);
    }
}