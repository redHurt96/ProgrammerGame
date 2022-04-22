using System;
using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class DailyBonusUpdateSystem : IInitSystem
    {
        public DailyBonusUpdateSystem()
        {
        }

        public void Init()
        {
            var lastSaveData = _gameData.SavableData.SaveDateTime;

            if (lastSaveData == 0)
                ClearDailyBoost();
            else
                UpDailyBoostIfNewDay(lastSaveData);
        }

        private void UpDailyBoostIfNewDay(long lastSaveData)
        {
            int saveDay = DateTime.FromBinary(lastSaveData).DayOfYear;
            int difference = DateTime.Now.DayOfYear - saveDay;

            if (difference == 1)
            {
                _gameData.DailyBonusData.Day++;
                _globalEvents.InvokeOnDailyBonusUpdate();
            }
            else if (difference > 1)
            {
                ClearDailyBoost();
            }
        }

        private void ClearDailyBoost() => 
            _gameData.DailyBonusData.Day = 0;
    }
}