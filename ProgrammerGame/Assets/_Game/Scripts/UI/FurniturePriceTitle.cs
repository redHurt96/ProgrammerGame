using AP.ProgrammerGame.Logic;

namespace AP.ProgrammerGame.Ui
{
    public class FurniturePriceTitle : BasePriceTitle
    {
        protected override string GetPrice() => FurnitureUpgradeManager.Instance.CalculatePrice().ToString();
    }
}