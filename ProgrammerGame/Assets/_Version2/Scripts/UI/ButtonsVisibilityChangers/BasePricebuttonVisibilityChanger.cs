using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BasePricebuttonVisibilityChanger : MonoBehaviour
    {
        private Button _button;
        protected abstract bool IsInteractable { get; }

        private void Start()
        {
            _button = GetComponent<Button>();

            GlobalEvents.MoneyCountChanged += UpdateButtonVisibility;

            UpdateButtonVisibility(0);
        }

        private void OnDestroy() =>
            GlobalEvents.MoneyCountChanged -= UpdateButtonVisibility;

        private void UpdateButtonVisibility(int obj)
        {
            _button.interactable = IsInteractable;
        }
    }
}