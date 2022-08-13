using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProjectStep_1 : IInitSystem
    {
        private readonly GameData _data;
        private readonly TutorialEvents _tutorialEvents;

        public TutorialBuyFirstProjectStep_1()
        {
            _data = Services.Get<GameData>();
            _tutorialEvents = Services.Get<TutorialEvents>();
        }

        public void Init()
        {
            if (!_data.PersistentData.TutorialData.Steps.Contains(TutorialStep.BuyFirstProject_1))
                _tutorialEvents.InvokeEvent(TutorialStep.BuyFirstProject_1);
        }
    }
}