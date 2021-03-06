using _Game.Data;
using _Game.Tutorial;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialRunFirstProjectStep_2 : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        protected override TutorialStep Step => TutorialStep.PerformFirstProject_2;

        protected override bool _waitCondition =>
            GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.BuyFirstProject_1)
            && GameData.Instance.SavableData.Projects[0].State == ProjectState.Active;

        protected override float _delay => 1f;
    }
}