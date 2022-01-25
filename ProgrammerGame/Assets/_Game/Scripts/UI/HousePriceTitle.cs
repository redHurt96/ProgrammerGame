using AP.ProgrammerGame.Logic;

namespace AP.ProgrammerGame.Ui
{
    public class HousePriceTitle : BasePriceTitle
    {
        protected override string GetPrice() => HouseUpgradeManager.Instance.CalculatePrice().ToString();
    }
}