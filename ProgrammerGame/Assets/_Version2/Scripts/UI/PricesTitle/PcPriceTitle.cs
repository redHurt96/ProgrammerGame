using System.Globalization;

namespace AP.ProgrammerGame_v2.UI
{
    public class PcPriceTitle : BasePriceText
    {
        protected override string _price => 
            GameData.Instance.PcPrice.ToString("F0");
    }
}