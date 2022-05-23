using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialResetForBoostStep : BaseTutorialWaitForStepSystem
    {
        private readonly GameData _data;

        public TutorialResetForBoostStep() => 
            _data = Services.Get<GameData>();

        protected override TutorialStep Step => TutorialStep.ResetForBoost_10;

        protected override bool _waitCondition =>
            _data.ContainsTutorialStep(TutorialStep.UpgradeHouse_9)
            && _data.CanReset();

        protected override float _delay => .5f;
    }
}