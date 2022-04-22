using _Game.Configs;
using _Game.Data;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyAnotherProjectStep : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        public TutorialBuyAnotherProjectStep()
        {
        }

        protected override TutorialStep Step => TutorialStep.BuyAnotherProject_6;

        protected override bool _waitCondition =>
            _gameData.SavableData.MoneyCount >= _gameData.SavableData.Projects[1].GetPrice(1)
            && _gameData.PersistentData.TutorialData.Steps.Contains(TutorialStep.TapForMoney_3)
            && _gameData.SavableData.Projects[1].State == ProjectState.NotPurchased;

        protected override float _delay => .5f;
    }
}