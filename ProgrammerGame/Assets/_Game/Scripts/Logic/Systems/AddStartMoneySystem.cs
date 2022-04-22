using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class AddStartMoneySystem : IInitSystem
    {
        private readonly GameData _gameData;
        private readonly GlobalEventsService _globalEvents;
        private readonly Settings _settings;

        public AddStartMoneySystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();
            _settings = Services.Instance.Single<Settings>();
        }

        public void Init()
        {
            if (_gameData.SavableData.Projects.All(x => x.State != ProjectState.Active))
                _globalEvents.IntentToChangeMoney(_settings.StartMoney);
        }
    }
}