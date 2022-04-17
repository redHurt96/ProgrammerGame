using _Game.Configs;
using _Game.Data;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProgrammerStep : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        protected override TutorialStep Step => TutorialStep.BuyFirstProgrammer_4;

        protected override bool _waitCondition =>
            GameData.Instance.SavableData.MoneyCount >= Settings.Instance.AllProgrammersSettings.Programmers[0].Price
            && GameData.Instance.TutorialData.Steps.Contains(TutorialStep.TapForMoney_3);

        protected override float _delay => 5f;
    }
}