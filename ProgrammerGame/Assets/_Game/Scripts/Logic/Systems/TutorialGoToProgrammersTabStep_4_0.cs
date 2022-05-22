using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class TutorialGoToProgrammersTabStep_4_0 : BaseTutorialWaitForStepSystem
    {
        private readonly GameData _data;
        private readonly Settings _settings;

        public TutorialGoToProgrammersTabStep_4_0()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
        }

        protected override TutorialStep Step => TutorialStep.GoToProgrammersTab_4_0;

        protected override bool _waitCondition =>
            _data.SavableData.MoneyCount >= _settings.AllProgrammersSettings.Programmers[0].GetPrice(0)
            && _data.PersistentData.TutorialData.Steps.Contains(TutorialStep.TapForMoney_3);

        protected override float _delay => 1f;
    }
}