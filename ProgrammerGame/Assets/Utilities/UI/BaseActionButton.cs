using UnityEngine;
using UnityEngine.UI;

namespace RH.Utilities.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseActionButton : MonoBehaviour
    {
        protected Button _button { get; private set; }

        protected abstract void PerformOnClick();

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PerformOnClick);
        }

        private void OnDestroy()
        {
            _button?.onClick.RemoveListener(PerformOnClick);
        }
    }
}