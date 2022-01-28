using RH.Utilities.SingletonAccess;

namespace AP.ProgrammerGame_v2
{
    public class GameData : Singleton<GameData>
    {
        public float CodeWritingTime = 5f;
        public float CodeWritingProgress = 0f;

        public float MoneyForCode => _moneyForCodeBase * _levelMoneyCoefficient;
        public float MoneyForBug => _moneyForBugBase * _levelMoneyCoefficient;

        public float MoneyCount = 0f;

        public float AccelerationCodeProgressPercent = .05f;

        public float Level = 0f;

        private float _moneyForCodeBase = 1f;
        private float _moneyForBugBase = 3f;

        private float _levelMoneyCoefficient => Settings.Instance.MoneyPerLevel.Evaluate(Level);
    }
}