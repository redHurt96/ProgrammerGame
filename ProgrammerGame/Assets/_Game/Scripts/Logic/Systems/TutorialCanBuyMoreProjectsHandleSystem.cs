using System.Collections;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialCanBuyMoreProjectsHandleSystem : IInitSystem
    {
        public void Init()
        {
            if (!GameData.Instance.TutorialData.Steps.Contains(TutorialStep.CanBuyMoreProjects_2))
                CoroutineLauncher.Start(DelayedInvoke());
        }

        private IEnumerator DelayedInvoke()
        {
            SavableData savableData = GameData.Instance.SavableData;

            yield return new WaitUntil(() => 
                savableData.MoneyCount >= savableData.Projects[1].GetPrice(1)
                && GameData.Instance.TutorialData.Steps.Contains(TutorialStep.TapMoney_1)
                && savableData.Projects[1].State == ProjectState.NotPurchased);

            yield return new WaitForSeconds(3f);

            TutorialEvents.Instance.InvokeEvent(TutorialStep.CanBuyMoreProjects_2);
        }
    }
}