using _Game.Tutorial;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProgrammerStep_4 : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        protected override TutorialStep Step => TutorialStep.BuyFirstProgrammer_4;

        protected override bool _waitCondition =>
            _data.PersistentData.TutorialData.Steps.Contains(TutorialStep.GoToProgrammersTab_4_0)
            && _data.SavableData.MoneyCount >= _settings.AllProgrammersSettings.Programmers[0].GetPrice(0);


        protected override float _delay => 0f;
    }
}