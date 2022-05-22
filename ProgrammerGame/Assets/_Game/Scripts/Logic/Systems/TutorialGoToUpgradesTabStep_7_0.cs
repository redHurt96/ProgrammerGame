using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;

namespace _Game.Logic.Systems
{
    public class TutorialGoToUpgradesTabStep_7_0 : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.GoToUpgradesTab_7_0;

        protected override bool _waitCondition =>
            GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.BuyAnotherProject_6)
            && GameData.Instance.SavableData.Projects[1].State == ProjectState.Active
            && GameData.Instance.SavableData.MoneyCount > Settings.Instance.PcUpgradeSettings.GetPrice(1);

        protected override float _delay => 1f;
    }
}