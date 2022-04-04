using System;
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

        public void SetPriceFunc(Func<long> calculatePrice)
        {
            _calculatePrice = calculatePrice;
            
            GlobalEvents.MoneyCountChanged += UpdateVisibility;

            UpdateVisibility();
        }

        private void OnDestroy() => 
            GlobalEvents.MoneyCountChanged -= UpdateVisibility;

        private void UpdateVisibility(long obj) => 
            _button.interactable = GameData.Instance.MoneyCount >= _calculatePrice?.Invoke();

        private void UpdateVisibility() => 
            UpdateVisibility(0);
    }
}