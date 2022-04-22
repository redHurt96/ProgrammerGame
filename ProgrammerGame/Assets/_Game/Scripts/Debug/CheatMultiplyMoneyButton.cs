using System.Threading;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Debug
{
    public class CheatMultiplyMoneyButton : BaseActionButton
    {
        public long Value = 100;

        private void Awake() => 
            GetComponentInChildren<Text>().text = $"x{Value}";

        [ContextMenu("Click")]
        protected override void PerformOnClick() => 
            Services.Instance.Single<GlobalEventsService>()
                .IntentToChangeMoney(Services.Instance.Single<GameData>().SavableData.MoneyCount * Value);
    }
}