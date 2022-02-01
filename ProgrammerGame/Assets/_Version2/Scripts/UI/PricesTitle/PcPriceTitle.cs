using System.Globalization;

namespace AP.ProgrammerGame.UI
{
    public class PcPriceTitle : BasePriceText
    {
        protected override string _price => 
            GameData.Instance.PcPrice.ToString("F0");
    }
}