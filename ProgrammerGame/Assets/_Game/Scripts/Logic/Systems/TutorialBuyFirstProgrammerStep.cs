﻿using _Game.Configs;
using _Game.Data;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TutorialBuyFirstProgrammerStep : BaseTutorialWaitForStepSystem
    {
        private Coroutine _coroutine;

        public TutorialBuyFirstProgrammerStep()
        {
        }

        protected override TutorialStep Step => TutorialStep.BuyFirstProgrammer_4;

        protected override bool _waitCondition =>
            _gameData.SavableData.MoneyCount >= _settings.AllProgrammersSettings.Programmers[0].Price
            && _gameData.PersistentData.TutorialData.Steps.Contains(TutorialStep.TapForMoney_3);

        protected override float _delay => 5f;
    }
}