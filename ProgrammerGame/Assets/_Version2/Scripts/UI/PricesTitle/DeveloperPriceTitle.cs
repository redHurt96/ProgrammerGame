using System.Globalization;

namespace AP.ProgrammerGame_v2.UI
{
    public class DeveloperPriceTitle : BasePriceText
    {
        protected override string _price => 
            GameData.Instance.DeveloperPrice.ToString("F0");
    }
}