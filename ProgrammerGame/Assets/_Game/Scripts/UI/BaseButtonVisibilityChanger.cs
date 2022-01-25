using System;
using AP.ProgrammerGame.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.Ui
{
    public abstract class BaseButtonVisibilityChanger : MonoBehaviour
    {
        public abstract bool CanShowButton { get; }

        [SerializeField] private Button _button;

        private void Start()
        {
            Wallet.Instance.CountChanged += UpdateVisibility;
            UpdateVisibility();
        }

        private void OnDestroy() => Wallet.Instance.CountChanged -= UpdateVisibility;

        private void UpdateVisibility() => _button.interactable = CanShowButton;
    }
}