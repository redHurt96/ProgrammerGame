using _Game.Scripts.Exception;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class EarnedWhileAwayWindow : MonoBehaviour
    {
        [SerializeField] private Text _countTitle;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundCloseButton;

        private long _countValue;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
            _backgroundCloseButton.onClick.AddListener(Close);
        }

        public void Enable(long count)
        {
            gameObject.SetActive(true);

            _countValue = count;

            _countTitle.text = count.ToPriceString();
        }

        private void Close()
        {
            GlobalEvents.IntentToChangeMoney(_countValue);

            _countValue = 0;

            gameObject.SetActive(false);
        }
    }
}
