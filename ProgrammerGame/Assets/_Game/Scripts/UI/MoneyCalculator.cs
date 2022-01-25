using AP.ProgrammerGame.Logic;

namespace AP.ProgrammerGame.Ui
{
    public static class MoneyCalculator
    {
        public static int MoneyForCode => (int)(Settings.Instance.MoneyForCode * _levelCoefficient);
        public static int MoneyForBug => (int)(Settings.Instance.MoneyForBug * _levelCoefficient);

        private static float _levelCoefficient =>
            Settings.Instance.HouseMoneyCoefficient.Evaluate(HouseUpgradeManager.Instance.Level)
            * Settings.Instance.FurnitureMoneyCoefficient.Evaluate(FurnitureUpgradeManager.Instance.Level);
    }
}