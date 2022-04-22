using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProjectStep : IInitSystem
    {
        public TutorialBuyFirstProjectStep()
        {
        }

        public void Init()
        {
            if (!_gameData.PersistentData.TutorialData.Steps.Contains(TutorialStep.BuyFirstProject_1))
                TutorialEvents.Instance.InvokeEvent(TutorialStep.BuyFirstProject_1);
        }
    }
}