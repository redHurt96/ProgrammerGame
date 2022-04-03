using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    [RequireComponent(typeof(Text))]
    public abstract class BasePriceText : MonoBehaviour
    {
        protected abstract string _price { get; }

        [SerializeField] private Text _text;

        private void Start()
        {
            GlobalEvents.MoneyCountChanged += UpdateTitle;
            UpdateTitle(0);
        }

        private void OnDestroy() => GlobalEvents.MoneyCountChanged -= UpdateTitle;

        private void UpdateTitle(long l) => _text.text = _price;
    }
}