using System;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    [RequireComponent(typeof(Button))]
    public class PriceButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private Func<double> _calculatePrice;
        private Func<bool> _additionalCondition;

        public void SetPriceFunc(Func<double> calculatePrice)
        {
            _calculatePrice = calculatePrice;

            EventsMediator.Instance.MoneyCountChanged += UpdateVisibility;
            EventsMediator.Instance.OnUpgraded += UpdateVisibility;

            UpdateVisibility();
        }

        public void SetAdditionalCondition(Func<bool> additionalCondition) => 
            _additionalCondition = additionalCondition;

        private void OnEnable() => 
            UpdateVisibility();

        private void OnDestroy()
        {
            EventsMediator.Instance.OnUpgraded -= UpdateVisibility;
            EventsMediator.Instance.MoneyCountChanged -= UpdateVisibility;
        }

        public void UpdateVisibility() => 
            UpdateVisibility(0d);

        private void UpdateVisibility(UpgradeType type) => 
            UpdateVisibility(0d);

        private void UpdateVisibility(double obj)
        {
            if (GameData.Instance == null)
            {
                _button.interactable = false;
                return;
            }

            _button.interactable = GameData.Instance.SavableData.MoneyCount >= _calculatePrice?.Invoke()
                                   && (_additionalCondition?.Invoke() ?? true);
        }
    }
}