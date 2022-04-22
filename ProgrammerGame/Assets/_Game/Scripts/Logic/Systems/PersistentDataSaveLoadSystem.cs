using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class PersistentDataSaveLoadSystem : BaseInitSystem
    {
        public PersistentDataSaveLoadSystem()
        {
        }

        public override void Init()
        {
            _gameData.PersistentData.LoadIfSaveExist();

            _globalEvents.TutorialStepReceived += Save;
            _globalEvents.LevelChanged += Save;
            _globalEvents.ApplicationPaused += Save;
        }

        public override void Dispose()
        {
            _gameData.PersistentData.Save();

            _globalEvents.TutorialStepReceived -= Save;
            _globalEvents.LevelChanged -= Save;
            _globalEvents.ApplicationPaused -= Save;
        }

        private void Save() => _gameData.PersistentData.Save();
    }
}