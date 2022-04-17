using _Game.Common;
using _Game.Configs;
using _Game.Data;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradeHouseStep : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.UpgradeHouse_9;

        protected override bool _waitCondition =>
            GameDataPresenter.Instance.CanBuyNewRoom();

        protected override float _delay => 2f;
    }
}