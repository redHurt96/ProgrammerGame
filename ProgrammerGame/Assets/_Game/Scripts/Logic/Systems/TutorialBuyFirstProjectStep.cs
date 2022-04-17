using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProjectStep : IInitSystem
    {
        public void Init()
        {
            if (!GameData.Instance.TutorialData.Steps.Contains(TutorialStep.BuyFirstProject_1))
            {
                UnityEngine.Debug.LogWarning("Run first step");

                TutorialEvents.Instance.InvokeEvent(TutorialStep.BuyFirstProject_1);
            }
        }
    }
}