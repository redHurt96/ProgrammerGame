using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class PersistentDataSaveLoadSystem : BaseInitSystem
    {
        private readonly GameData _data;
        private readonly EventsMediator _events;

        public PersistentDataSaveLoadSystem()
        {
            _data = Services.Get<GameData>();
            _events = Services.Get<EventsMediator>();
        }

        public override void Init()
        {
            _data.PersistentData.LoadIfExist();



            _events.TutorialStepReceived += Save;
            _events.LevelChanged += Save;
            _events.ApplicationPaused += Save;
        }

        public override void Dispose()
        {
            _data.PersistentData.Save();

            _events.TutorialStepReceived -= Save;
            _events.LevelChanged -= Save;
            _events.ApplicationPaused -= Save;
        }

        private void Save() => _data.PersistentData.Save();
    }
}