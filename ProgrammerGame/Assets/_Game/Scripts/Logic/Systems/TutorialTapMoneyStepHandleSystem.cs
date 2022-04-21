using _Game.Configs;
using _Game.Data;

namespace _Game.Logic.Systems
{
    public class TutorialTapMoneyStepHandleSystem : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.TapForMoney_3;

        protected override bool _waitCondition =>
            GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.PerformFirstProject_2);

        protected override float _delay => 5f;
    }
}