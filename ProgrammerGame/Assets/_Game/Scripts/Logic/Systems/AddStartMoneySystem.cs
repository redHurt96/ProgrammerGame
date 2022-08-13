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
        private readonly GameData _data;
        private readonly EventsMediator _events;
        private readonly Settings _settings;

        public AddStartMoneySystem()
        {
            _data = Services.Get<GameData>();
            _events = Services.Get<EventsMediator>();
            _settings = Services.Get<Settings>();
        }

        public void Init()
        {
            if (_data.SavableData.Projects.All(x => x.State != ProjectState.Active))
                _events.IntentToChangeMoney(_settings.StartMoney);
        }
    }
}