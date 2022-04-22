using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ChangeMoneyCountSystem : BaseInitSystem, IChangeMoneySystem
    {
        private readonly GameDataPresenter _gameDataPresenter;
        private readonly GlobalEventsService _globalEvents;
        private readonly GameData _gameData;

        public ChangeMoneyCountSystem()
        {
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();
        }

        public override void Init() => 
            _globalEvents.ChangeMoneyIntent += ChangeMoneyCount;

        public override void Dispose() => 
            _globalEvents.ChangeMoneyIntent -= ChangeMoneyCount;

        private void ChangeMoneyCount(double amount)
        {
            _gameData.SavableData.MoneyCount += amount;
            _globalEvents.ChangeMoneyCount(amount, this);
        }
    }
}