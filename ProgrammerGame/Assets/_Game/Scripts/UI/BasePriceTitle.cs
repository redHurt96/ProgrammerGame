using AP.ProgrammerGame.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.Ui
{
    public abstract class BasePriceTitle : MonoBehaviour
    {
        [SerializeField] private Text _title;
        
        private void Start() => Wallet.Instance.CountChanged += UpdateTitle;
        private void OnDestroy() => Wallet.Instance.CountChanged -= UpdateTitle;

        protected abstract string GetPrice();

        private void UpdateTitle() => _title.text = GetPrice();
    }
}