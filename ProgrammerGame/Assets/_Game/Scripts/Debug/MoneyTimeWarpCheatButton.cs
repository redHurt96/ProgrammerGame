using _Game.Common;
using _Game.Data;
using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Debug
{
    public class MoneyTimeWarpCheatButton : BaseActionButton
    {
        public long TimeSec = 100;

        private void Awake() => 
            GetComponentInChildren<Text>().text = $"{TimeSec} s";

        [ContextMenu("Click")]
        protected override void PerformOnClick() => 
            GlobalEvents.Instance.IntentToChangeMoney(GameData.Instance.IncomePerSec * TimeSec);
    }
}