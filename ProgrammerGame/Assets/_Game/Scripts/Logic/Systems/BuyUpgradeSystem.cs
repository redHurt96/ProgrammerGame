using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class BuyUpgradeSystem : BaseInitSystem
    {
        private readonly GameDataPresenter _gameDataPresenter;

        public BuyUpgradeSystem()
        {
            _gameDataPresenter = Services.Get<GameDataPresenter>();
        }
        
        public override void Init() => 
            GlobalEvents.Instance.BuyUpgradeIntent += BuyUpgrade;

        public override void Dispose() => 
            GlobalEvents.Instance.BuyUpgradeIntent -= BuyUpgrade;

        private void BuyUpgrade(UpgradeType type, double price)
        {
            GlobalEvents.Instance.IntentToChangeMoney(-price);
            _gameDataPresenter.GetUpgradeData(type).Upgrade();
            GlobalEvents.Instance.InvokeAfterUpgradeEvent(type);
        }
    }
}