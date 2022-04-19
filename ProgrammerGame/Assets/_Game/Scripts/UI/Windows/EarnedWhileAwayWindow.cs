using _Game.Common;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class EarnedWhileAwayWindow : BaseWindow
    {
        [SerializeField] private Text _countTitle;

        private double _countValue;

        public void SetCount(double count)
        {
            gameObject.SetActive(true);

            _countValue = count;

            _countTitle.text = count.ToPriceString();
        }

        protected override void PerformBeforeClose()
        {
            GlobalEvents.Instance.IntentToChangeMoney(_countValue);

            _countValue = 0;
        }
    }
}
