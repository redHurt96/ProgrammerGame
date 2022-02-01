using System.Globalization;

namespace AP.ProgrammerGame.UI
{
    public class DeveloperPriceTitle : BasePriceText
    {
        protected override string _price => 
            GameData.Instance.DeveloperPrice.ToString("F0");
    }
}