using System;
using System.Globalization;
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
            _closeButton.onClick.AddListener(Close);
            _backgroundCloseButton.onClick.AddListener(Close);
        }

        private void Close()
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