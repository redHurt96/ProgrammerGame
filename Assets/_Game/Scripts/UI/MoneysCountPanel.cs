using AP.ProgrammerGame.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.Ui
{
    public class MoneysCountPanel : MonoBehaviour
    {
        [SerializeField] private Text _title;

        private void Start()
        {
            UpdateText();
            Wallet.Instance.CountChanged += UpdateText;
        }

        private void UpdateText() => 
            _title.text = Wallet.Instance.FakeMoneyCount.ToString();
    }
}