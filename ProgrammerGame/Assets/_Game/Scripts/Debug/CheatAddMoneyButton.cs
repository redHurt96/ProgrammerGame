using AP.ProgrammerGame;
using RH.Utilities.UI;
using UnityEngine.UI;

namespace _Game.Debug
{
    public class CheatAddMoneyButton : BaseActionButton
    {
        public long Value = 100;

        private void Awake() => 
            GetComponentInChildren<Text>().text = Value.ToString();

        protected override void PerformOnClick() => 
            GlobalEvents.IntentToChangeMoney(Value);
    }
}