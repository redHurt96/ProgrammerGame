using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialBuyEnoughFurnitureStep : BaseTutorialWaitForStepSystem
    {
        private readonly GameDataPresenter _gameDataPresenter;

        public TutorialBuyEnoughFurnitureStep()
        {
            _gameDataPresenter = Services.Get<GameDataPresenter>();
        }
        
        protected override TutorialStep Step => TutorialStep.BuyEnoughFurniture_8;

        protected override bool _waitCondition =>
            GameData.Instance.PersistentData.TutorialData.Steps.Contains(TutorialStep.UpgradePcOrFurniture_7)
            && (_gameDataPresenter.GetUpgradeData(UpgradeType.PC).Level > 0 ||
                _gameDataPresenter.GetUpgradeData(UpgradeType.Interior).Level > 0);

        protected override float _delay => 1f;
    }
}