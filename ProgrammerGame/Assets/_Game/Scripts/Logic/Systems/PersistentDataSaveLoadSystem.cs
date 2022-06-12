using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class PersistentDataSaveLoadSystem : BaseInitSystem
    {
        public override void Init()
        {
            GameData.Instance.PersistentData.LoadIfExist();

            EventsMediator.Instance.TutorialStepReceived += Save;
            EventsMediator.Instance.LevelChanged += Save;
            EventsMediator.Instance.ApplicationPaused += Save;
        }

        public override void Dispose()
        {
            GameData.Instance.PersistentData.Save();

            EventsMediator.Instance.TutorialStepReceived -= Save;
            EventsMediator.Instance.LevelChanged -= Save;
            EventsMediator.Instance.ApplicationPaused -= Save;
        }

        private void Save() => GameData.Instance.PersistentData.Save();
    }
}