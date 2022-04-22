using _Game.Configs;
using _Game.Data;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradePcStep : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.UpgradePcOrFurniture_7;

        protected override bool _waitCondition =>
            _gameData.PersistentData.TutorialData.Steps.Contains(TutorialStep.BuyAnotherProject_6)
            && _gameData.SavableData.Projects[1].State == ProjectState.Active
            && _gameData.SavableData.MoneyCount > _settings.PcUpgradeSettings.GetPrice(1);

        protected override float _delay => 1f;
    }
}