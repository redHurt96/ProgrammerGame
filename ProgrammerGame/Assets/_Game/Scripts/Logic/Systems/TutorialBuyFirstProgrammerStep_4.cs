using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProgrammerStep_4 : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;
        private readonly GameData _data;

        public TutorialBuyFirstProgrammerStep_4() => 
            _data = Services.Get<GameData>();

        protected override TutorialStep Step => TutorialStep.BuyFirstProgrammer_4;

        protected override bool _waitCondition =>
            _data.PersistentData.TutorialData.Steps.Contains(TutorialStep.GoToProgrammersTab_4_0);

        protected override float _delay => 5f;
    }
}