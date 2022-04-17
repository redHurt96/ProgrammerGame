using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Windows
{
    public class DailyBonusWindow : BaseWindow
    {
        [SerializeField] private Text _day;
        [SerializeField] private Text _boost;

        private DailyBonusData _dailyBonusData => GameData.Instance.DailyBonusData;

        protected override void PerformBeforeOpen()
        {
            _day.text = _dailyBonusData.Day.ToString();
            _boost.text = _dailyBonusData.Bonus.ToString("F1");
        }
    }
}