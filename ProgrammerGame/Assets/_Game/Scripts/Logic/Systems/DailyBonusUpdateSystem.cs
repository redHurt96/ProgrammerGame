using System;
using _Game.Common;
using _Game.Data;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class DailyBonusUpdateSystem : IInitSystem
    {
        public void Init()
        {
            var lastSaveData = GameData.Instance.SavableData.SaveDateTime;

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
                GameData.Instance.DailyBonusData.Day++;
                GlobalEvents.InvokeOnDailyBonusUpdate();
            }
            else if (difference > 1)
            {
                ClearDailyBoost();
            }
        }

        private void ClearDailyBoost() => 
            GameData.Instance.DailyBonusData.Day = 0;
    }
}