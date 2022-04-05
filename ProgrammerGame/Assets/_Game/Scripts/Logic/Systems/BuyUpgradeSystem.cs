using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class BuyUpgradeSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.BuyUpgradeIntent += BuyUpgrade;

        public override void Dispose() => 
            GlobalEvents.BuyUpgradeIntent -= BuyUpgrade;

        private void BuyUpgrade(UpgradeType type, long price)
        {
            GlobalEvents.IntentToChangeMoney(-price);
            GameDataPresenter.Instance.GetUpgradeData(type).Upgrade();
        }
    }
}