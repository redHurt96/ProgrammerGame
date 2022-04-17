using _Game.Common;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class EarnedWhileAwayWindow : BaseWindow
    {
        [SerializeField] private Text _countTitle;

        private long _countValue;

        public void SetCount(long count)
        {
            gameObject.SetActive(true);

            _countValue = count;

            _countTitle.text = count.ToPriceString();
        }

        protected override void PerformBeforeClose()
        {
            GlobalEvents.IntentToChangeMoney(_countValue);

            _countValue = 0;
        }
    }
}
