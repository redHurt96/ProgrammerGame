using RH.Utilities.SingletonAccess;
using System;

namespace AP.ProgrammerGame_v2.Logic
{
    public class Wallet : Singleton<Wallet>
    {
        public Wallet()
        {
            GlobalEvents.CodeWrittenComplete += AddMoneyForCode;
            GlobalEvents.BugCatched += AddMoneyForBug;
        }

        protected override void PrepareToDestroy()
        {
            GlobalEvents.CodeWrittenComplete -= AddMoneyForCode;
            GlobalEvents.BugCatched -= AddMoneyForBug;
        }

        public void ChangeMoneyCount(int amount)
        {
            GameData.Instance.MoneyCount += amount;
            GlobalEvents.ChangeMoneyCount(amount);
        }

        private void AddMoneyForCode() => ChangeMoneyCount(GameData.Instance.MoneyForCode);
        private void AddMoneyForBug() => ChangeMoneyCount(GameData.Instance.MoneyForBug);
    }
}