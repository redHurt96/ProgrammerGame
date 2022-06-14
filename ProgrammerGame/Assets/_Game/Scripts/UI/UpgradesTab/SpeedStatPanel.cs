using _Game.Data;

namespace _Game.UI.UpgradesTab
{
    public class SpeedStatPanel : StatPanel
    {
        protected override float Value => _data.SpeedTotalEffect();
    }
}