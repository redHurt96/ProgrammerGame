using _Game.Data;

namespace _Game.UI.UpgradesTab
{
    public class MoneyStatPanel : StatPanel
    {
        protected override float Value => _data.MoneyTotalEffect();
    }
}