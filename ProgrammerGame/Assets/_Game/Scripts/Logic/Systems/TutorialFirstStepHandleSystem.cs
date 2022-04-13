using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class TutorialFirstStepHandleSystem : IInitSystem
    {
        public void Init()
        {
            if (!GameData.Instance.TutorialData.Steps.Contains(TutorialStep.FirstStart_0))
                TutorialEvents.Instance.InvokeEvent(TutorialStep.FirstStart_0);
        }
    }
}