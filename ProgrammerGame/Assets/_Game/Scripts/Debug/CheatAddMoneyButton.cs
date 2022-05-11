using _Game.Common;
using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Debug
{
    public class CheatAddMoneyButton : BaseActionButton
    {
        public long Value = 100;

        private void Awake() => 
            GetComponentInChildren<Text>().text = $"+{Value}";
        
        [ContextMenu("Click")]
        protected override void PerformOnClick() => 
            GlobalEvents.Instance.IntentToChangeMoney( Value);
    }
}