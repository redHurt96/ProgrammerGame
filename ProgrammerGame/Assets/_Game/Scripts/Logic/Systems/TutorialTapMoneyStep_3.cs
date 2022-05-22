using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;

namespace _Game.Logic.Systems
{
    public class TutorialTapMoneyStep_3 : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.TapForMoney_3;

        protected override bool _waitCondition =>
            GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.PerformFirstProject_2);

        protected override float _delay => 5f;
    }
}