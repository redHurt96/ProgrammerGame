using System;
using _Game.Data;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Projects
{
    [RequireComponent(typeof(Button))]
    public class PriceButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private Func<long> _calculatePrice;
        private Func<bool> _additionalCondition;

        public void SetPriceFunc(Func<long> calculatePrice)
        {
            _calculatePrice = calculatePrice;

            GlobalEvents.MoneyCountChanged += UpdateVisibility;
            GlobalEvents.OnUpgraded += UpdateVisibility;

            UpdateVisibility();
        }

        public void SetAdditionalCondition(Func<bool> additionalCondition) => 
            _additionalCondition = additionalCondition;

        private void OnDestroy()
        {
            GlobalEvents.OnUpgraded -= UpdateVisibility;
            GlobalEvents.MoneyCountChanged -= UpdateVisibility;
        }

        private void UpdateVisibility(long obj) => 
            _button.interactable = GameData.Instance.SavableData.MoneyCount >= _calculatePrice?.Invoke() 
                                   && (_additionalCondition?.Invoke() ?? true);

        private void UpdateVisibility() => UpdateVisibility(0L);
        private void UpdateVisibility(UpgradeType type) => UpdateVisibility(0L);
    }
}