using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyAnotherProjectStep_6 : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        protected override TutorialStep Step => TutorialStep.BuyAnotherProject_6;

        protected override bool _waitCondition =>
            GameData.Instance.SavableData.MoneyCount >= GameData.Instance.SavableData.Projects[1].GetPrice(1)
            && GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.TapForMoney_3)
            && GameData.Instance.SavableData.Projects[1].State == ProjectState.NotPurchased;

        protected override float _delay => .5f;
    }
}