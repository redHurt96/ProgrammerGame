using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class ChangeMoneyCountSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.ChangeMoneyIntent += ChangeMoneyCount;

        public override void Dispose() => 
            GlobalEvents.ChangeMoneyIntent -= ChangeMoneyCount;

        private void ChangeMoneyCount(long amount)
        {
            GameData.Instance.SavableData.MoneyCount += amount;
            GlobalEvents.ChangeMoneyCount(amount, this);
        }
    }
}