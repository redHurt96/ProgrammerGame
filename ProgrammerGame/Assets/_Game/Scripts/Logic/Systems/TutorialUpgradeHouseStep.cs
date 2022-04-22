using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradeHouseStep : BaseTutorialWaitForStepSystem
    {
        private readonly GameDataPresenter _gameDataPresenter;

        public TutorialUpgradeHouseStep()
        {
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
        }

        protected override TutorialStep Step => TutorialStep.UpgradeHouse_9;

        protected override bool _waitCondition =>
            _gameDataPresenter.CanBuyNewRoom();

        protected override float _delay => 2f;
    }
}