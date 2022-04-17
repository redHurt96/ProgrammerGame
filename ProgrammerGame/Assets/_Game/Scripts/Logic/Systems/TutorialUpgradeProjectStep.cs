using _Game.Configs;
using _Game.Data;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradeProjectStep : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.UpgradeProject_5;

        protected override bool _waitCondition => 
            GameData.Instance.SavableData.AutoRunnedProjects.Count > 0;

        protected override float _delay => 1f;
    }
}