using _Game.Common;
using AP.ProgrammerGame;
using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Debug
{
    public class CheatAddMoneyButton : BaseActionButton
    {
        public long Value = 100;

        private void Awake() => 
            GetComponentInChildren<Text>().text = $"x{Value}";

        protected override void PerformOnClick() => 
            GlobalEvents.IntentToChangeMoney( (long) Mathf.Max(1, GameDataPresenter.Instance.IncomePerSec * Value));
    }
}