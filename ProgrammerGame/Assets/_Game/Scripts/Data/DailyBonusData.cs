using System;
using _Game.Configs;
using RH.Utilities.Saving;
using RH.Utilities.ServiceLocator;

namespace _Game.Data
{
    [Serializable]
    public class DailyBonusData : ISavableData
    {
        private Settings Settings => _settings ??= Services.Get<Settings>();

        public int Day;
        public float Bonus => 1 + Day * Settings.DailyBonusPerDay;
        public string Key => "Daily bonus";
        
        private Settings _settings;
    }
}