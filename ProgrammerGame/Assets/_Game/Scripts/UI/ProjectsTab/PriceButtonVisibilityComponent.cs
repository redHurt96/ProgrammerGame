using System;
using _Game.Common;
using _Game.Data;
using RH.Utilities.ServiceLocator;
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
        
        private EventsMediator _events;
        private GameData _data;

        public void SetPriceFunc(Func<double> calculatePrice)
        {
            _events ??= Services.Get<EventsMediator>();
            _data ??= Services.Get<GameData>();
            
            _calculatePrice = calculatePrice;

            _events.MoneyCountChanged += UpdateVisibility;
            _events.OnUpgraded += UpdateVisibility;

            UpdateVisibility();
        }

        private void OnEnable() => 
            UpdateVisibility();

        private void OnDestroy()
        {
            if (_events == null)
                return;
            
            _events.OnUpgraded -= UpdateVisibility;
            _events.MoneyCountChanged -= UpdateVisibility;
        }

        public void SetAdditionalCondition(Func<bool> additionalCondition) => 
            _additionalCondition = additionalCondition;

        public void UpdateVisibility(double obj = 0)
        {
            if (_data == null)
            {
                _button.interactable = false;
                return;
            }

            _button.interactable = _data.SavableData.MoneyCount >= _calculatePrice?.Invoke()
                                   && (_additionalCondition?.Invoke() ?? true);
        }

        private void UpdateVisibility(UpgradeType type) => 
            UpdateVisibility();
    }
}