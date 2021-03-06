using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialUpgradePcStep_7 : BaseTutorialWaitForStepSystem
    {
        private readonly GameData _data;

        public TutorialUpgradePcStep_7() => 
            _data = Services.Get<GameData>();

        protected override TutorialStep Step => TutorialStep.UpgradePcOrFurniture_7;

        protected override bool _waitCondition =>
            _data.PersistentData.TutorialData.Steps.Contains(TutorialStep.GoToUpgradesTab_7_0)
            && GameData.Instance.SavableData.MoneyCount > Settings.Instance.PcPrices.GetPrice(1);

        protected override float _delay => 0f;
    }
}