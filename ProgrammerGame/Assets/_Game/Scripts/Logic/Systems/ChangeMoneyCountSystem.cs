using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class ChangeMoneyCountSystem : BaseInitSystem, IChangeMoneySystem
    {
        public override void Init() => 
            GlobalEvents.Instance.ChangeMoneyIntent += ChangeMoneyCount;

        public override void Dispose() => 
            GlobalEvents.Instance.ChangeMoneyIntent -= ChangeMoneyCount;

        private void ChangeMoneyCount(double amount)
        {
            GameData.Instance.SavableData.MoneyCount += amount;

            if (GameData.Instance.SavableData.MoneyCount < 0)
            {
                UnityEngine.Debug.LogError($"Removing more money then player has - {amount} from {StackTraceUtility.ExtractStackTrace()}");
                GameData.Instance.SavableData.MoneyCount = 0;
            }

            GlobalEvents.Instance.ChangeMoneyCount(amount, this);
        }
    }
}