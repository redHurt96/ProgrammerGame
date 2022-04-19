using _Game.Common;
using _Game.Data;
using RH.Utilities.ComponentSystem;

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
            GlobalEvents.Instance.ChangeMoneyCount(amount, this);
        }
    }
}