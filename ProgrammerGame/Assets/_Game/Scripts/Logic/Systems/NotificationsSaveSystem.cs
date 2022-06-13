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
        private readonly EventsMediator _eventsMediator;

        public NotificationsSaveSystem()
        {
            _data = Services.Get<GameData>().Notifications;
            _eventsMediator = Services.Get<EventsMediator>();
        }

        public override void Init()
        {
            _data.LoadIfExist();
            _eventsMediator.ApplicationPaused += Save;
        }

        private void Save() =>
            _data.Save();

        public override void Dispose() =>
            _eventsMediator.ApplicationPaused -= Save;
    }
}