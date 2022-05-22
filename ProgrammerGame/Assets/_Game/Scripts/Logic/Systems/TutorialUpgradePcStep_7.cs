using _Game.Data;
using _Game.Tutorial;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradePcStep_7 : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.UpgradePcOrFurniture_7;

        protected override bool _waitCondition =>
            GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.GoToUpgradesTab_7_0);

        protected override float _delay => 2f;
    }
}