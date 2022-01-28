using System;

namespace AP.ProgrammerGame_v2.Logic
{
    public class Wallet : IDisposable
    {
        public Wallet()
        {
            GlobalEvents.CodeWrittenComplete += AddMoneyForCode;
            GlobalEvents.BugCatched += AddMoneyForBug;
        }

        public void Dispose()
        {
            GlobalEvents.CodeWrittenComplete -= AddMoneyForCode;
            GlobalEvents.BugCatched -= AddMoneyForBug;
        }

        private void AddMoneyForCode() => AddMoney(GameData.Instance.MoneyForCode);
        private void AddMoneyForBug() => AddMoney(GameData.Instance.MoneyForBug);

        private void AddMoney(float amount)
        {
            GameData.Instance.MoneyCount += amount;
            GlobalEvents.AddMoney(amount);
        }
    }
}