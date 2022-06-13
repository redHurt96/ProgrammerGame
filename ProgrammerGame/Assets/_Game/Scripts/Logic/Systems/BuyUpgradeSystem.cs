using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class BuyUpgradeSystem : BaseInitSystem
    {
        public override void Init() => 
            EventsMediator.Instance.BuyUpgradeIntent += BuyUpgrade;

        public override void Dispose() => 
            EventsMediator.Instance.BuyUpgradeIntent -= BuyUpgrade;

        private void BuyUpgrade(UpgradeType type)
        {
            GameData.Instance.GetUpgradeData(type).Upgrade();
            EventsMediator.Instance.InvokeAfterUpgradeEvent(type);
        }
    }
}