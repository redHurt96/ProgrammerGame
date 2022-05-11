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
            GameData.Instance.PersistentData.LoadIfSaveExist();

            GlobalEvents.Instance.TutorialStepReceived += Save;
            GlobalEvents.Instance.LevelChanged += Save;
            GlobalEvents.Instance.ApplicationPaused += Save;
        }

        public override void Dispose()
        {
            GameData.Instance.PersistentData.Save();

            GlobalEvents.Instance.TutorialStepReceived -= Save;
            GlobalEvents.Instance.LevelChanged -= Save;
            GlobalEvents.Instance.ApplicationPaused -= Save;
        }

        private void Save() => GameData.Instance.PersistentData.Save();
    }
}