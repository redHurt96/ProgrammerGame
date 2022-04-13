using System.Collections;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialTapMoneyStepHandleSystem : IInitSystem
    {
        public void Init()
        {
            if (!GameData.Instance.TutorialData.Steps.Contains(TutorialStep.TapMoney_1)
                && GameData.Instance.TutorialData.Steps.Contains(TutorialStep.FirstStart_0))
            {
                CoroutineLauncher.Start(DelayedInvoke());
            }
        }

        private IEnumerator DelayedInvoke()
        {
            yield return new WaitForSeconds(10f);

            TutorialEvents.Instance.InvokeEvent(TutorialStep.TapMoney_1);
        }
    }
}