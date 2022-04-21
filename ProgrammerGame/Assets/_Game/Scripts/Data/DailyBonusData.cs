using System;
using _Game.Configs;
using RH.Utilities.Saving;

namespace _Game.Data
{
    [Serializable]
    public class DailyBonusData : ISavableData
    {
        public int Day;
        public float Bonus => 1 + Day * Settings.Instance.DailyBonusPerDay;
        public string Key => "Daily bonus";
    }
}