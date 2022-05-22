using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyAnotherProjectStep_6 : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;
        private readonly GameData _data;

        public TutorialBuyAnotherProjectStep_6() => 
            _data = Services.Get<GameData>();

        protected override TutorialStep Step => TutorialStep.BuyAnotherProject_6;

        protected override bool _waitCondition =>
            _data.SavableData.MoneyCount >= _data.SavableData.Projects[1].GetPrice(1)
            && _data.ContainsTutorialStep(TutorialStep.UpgradeProject_5)
            && _data.SavableData.Projects[1].State == ProjectState.NotPurchased;

        protected override float _delay => 0f;
    }
}