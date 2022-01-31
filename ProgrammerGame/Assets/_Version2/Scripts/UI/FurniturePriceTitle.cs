using System.Globalization;

namespace AP.ProgrammerGame_v2.UI
{
    public class FurniturePriceTitle : BasePriceText
    {
        protected override string _price => 
            GameData.Instance.FurniturePrice.ToString(CultureInfo.CurrentCulture);
    }
}