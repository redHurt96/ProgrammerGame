namespace AP.ProgrammerGame.UI
{
    public class FurniturePriceTitle : BasePriceText
    {
        protected override string _price => 
            GameData.Instance.FurniturePrice.ToString("F0");
    }
}