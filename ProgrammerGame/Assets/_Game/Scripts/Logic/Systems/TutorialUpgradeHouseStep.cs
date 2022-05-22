using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradeHouseStep : BaseTutorialWaitForStepSystem
    {
        private readonly GameData _data;
        private Settings _settings;

        public TutorialUpgradeHouseStep()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
        }

        protected override TutorialStep Step => TutorialStep.UpgradeHouse_9;

        protected override bool _waitCondition =>
            _data.CanBuyNewRoom()
            && _data.SavableData.MoneyCount >
            _settings.HousePrices.GetPrice(1);

        protected override float _delay => 2f;
    }
}