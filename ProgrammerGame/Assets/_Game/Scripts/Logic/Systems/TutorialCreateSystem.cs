using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using _Game.UI.Tutorial;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialCreateSystem : IInitSystem
    {
        private readonly GameData _gameData;
        private readonly TutorialEvents _tutorialEvents;

        public TutorialCreateSystem()
        {
            _gameData = Services.Instance.Single<GameData>();
            _tutorialEvents = Services.Instance.Single<TutorialEvents>();
        }

        public void Init()
        {
            foreach (TutorialWindow window in TutorialSettings.Instance.Windows)
            {
                if (!_gameData.PersistentData.TutorialData.Steps.Contains(window.Step))
                    _tutorialEvents.CreateActionFrom(window);
            }
        }
    }
}