using RH.Utilities.SingletonAccess;

namespace AP.ProgrammerGame_v2
{
    public class GameData : Singleton<GameData>
    {
        public float CodeWritingTime = 5f;
        public float CodeWritingProgress = 0f;
        public float AccelerationCodeProgressPercent = .05f;

        public int MoneyForCode => (int)(_moneyForCodeBase * _levelMoneyCoefficient);
        public int MoneyForBug => (int)(_moneyForBugBase * _levelMoneyCoefficient);

        public int MoneyCount = 0;

        public float Level = 0f;

        public int FurniturePrice => (int)Settings.Instance.MoneyPerFurniture.Evaluate(PurchasedFurnitureCount);
        public int PcPrice => (int)Settings.Instance.MoneyPerComputer.Evaluate(PurchasedComputersCount);
        public int DeveloperPrice => (int)Settings.Instance.MoneyPerDeveloper.Evaluate(PurchasedDevelopersCount);

        public int PurchasedFurnitureCount = 0;
        public int PurchasedComputersCount = 1;
        public int PurchasedDevelopersCount = 0;

        private int _moneyForCodeBase = 1;
        private int _moneyForBugBase = 3;

        private float _levelMoneyCoefficient => Settings.Instance.MoneyPerLevel.Evaluate(Level);
    }
}