using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class NotificationsSaveSystem : BaseInitSystem
    {
        private readonly NotificationData _data;
        private readonly GlobalEvents _events;

        public NotificationsSaveSystem()
        {
            _data = Services.Get<GameData>().Notifications;
            _events = Services.Get<GlobalEvents>();
        }

        public override void Init()
        {
            _data.LoadIfExist();
            _events.ApplicationPaused += Save;
        }

        private void Save() =>
            _data.Save();

        public override void Dispose() =>
            _events.ApplicationPaused -= Save;
    }
}