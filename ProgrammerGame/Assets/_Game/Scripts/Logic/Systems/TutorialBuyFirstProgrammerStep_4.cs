using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProgrammerStep_4 : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        private readonly GameData _data;
        private readonly Settings _settings;

        public TutorialBuyFirstProgrammerStep_4()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
        }

        protected override TutorialStep Step => TutorialStep.BuyFirstProgrammer_4;

        protected override bool _waitCondition =>
            _data.PersistentData.TutorialData.Steps.Contains(TutorialStep.GoToProgrammersTab_4_0)
            && _data.SavableData.MoneyCount >= _settings.AllProgrammersSettings.Programmers[0].GetPrice(0);


        protected override float _delay => 2f;
    }
}