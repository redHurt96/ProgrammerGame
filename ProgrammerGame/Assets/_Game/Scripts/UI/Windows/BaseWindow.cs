using System;
using _Game.Common;
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

        protected GameDataPresenter _gameDataPresenter;

        private void Awake()
        {
            if (_closeButton != null)
                _closeButton.onClick.AddListener(Close);
            
            if (_backgroundCloseButton != null)
                _backgroundCloseButton.onClick.AddListener(Close);
        }

        private void Start() => 
            _gameDataPresenter = Services.Get<GameDataPresenter>();

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