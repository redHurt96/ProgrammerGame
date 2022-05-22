using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradeProjectStep_5 : BaseTutorialWaitForStepSystem
    {
        private readonly GameData _data;

        public TutorialUpgradeProjectStep_5() => 
            _data = Services.Get<GameData>();

        protected override TutorialStep Step => TutorialStep.UpgradeProject_5;

        protected override bool _waitCondition =>
            _data.ContainsTutorialStep(TutorialStep.TapForMoney_3);

        protected override float _delay => 1f;
    }
}