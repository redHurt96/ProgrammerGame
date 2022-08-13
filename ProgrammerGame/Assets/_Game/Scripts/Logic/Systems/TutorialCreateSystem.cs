using _Game.Data;
using _Game.Tutorial;
using _Game.UI.Tutorial;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialCreateSystem : IInitSystem
    {
        private readonly TutorialSettings _tutorialSettings;
        private readonly TutorialEvents _tutorialEvents;

        public TutorialCreateSystem()
        {
            _tutorialSettings = Services.Get<TutorialSettings>();
            _tutorialEvents = Services.Get<TutorialEvents>();
        }

        public void Init()
        {
            foreach (TutorialWindow window in _tutorialSettings.Windows)
            {
                if (!GameData.Instance.PersistentData.TutorialData.Steps.Contains(window.Step))
                    _tutorialEvents.CreateActionFrom(window);
            }
        }
    }
}