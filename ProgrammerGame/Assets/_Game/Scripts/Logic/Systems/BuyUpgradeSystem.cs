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
        private readonly GlobalEventsService _globalEvents;

        public BuyUpgradeSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
        }

        public override void Init() => 
            _globalEvents.BuyUpgradeIntent += BuyUpgrade;

        public override void Dispose() => 
            _globalEvents.BuyUpgradeIntent -= BuyUpgrade;

        private void BuyUpgrade(UpgradeType type, double price)
        {
            _globalEvents.IntentToChangeMoney(-price);
            _gameDataPresenter.GetUpgradeData(type).Upgrade();
            _globalEvents.InvokeAfterUpgradeEvent(type);
        }
    }
}