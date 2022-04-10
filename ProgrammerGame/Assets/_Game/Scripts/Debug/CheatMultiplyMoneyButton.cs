using AP.ProgrammerGame;
using RH.Utilities.UI;
using UnityEngine.UI;

namespace _Game.Debug
{
    public class CheatMultiplyMoneyButton : BaseActionButton
    {
        public long Value = 100;

        private void Awake() => 
            GetComponentInChildren<Text>().text = $"x{Value}";

        protected override void PerformOnClick() => 
            GlobalEvents.IntentToChangeMoney(GameData.Instance.SavableData.MoneyCount * Value);
    }
}