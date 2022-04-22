using System;
using _Game.Configs;
using RH.Utilities.Saving;
using RH.Utilities.ServiceLocator;

namespace _Game.Data
{
    [Serializable]
    public class DailyBonusData : ISavableData
    {
        public int Day;
        public float Bonus => 1 + Day * _settings.DailyBonusPerDay;
        public string Key => "Daily bonus";

        private readonly Settings _settings;

        public DailyBonusData()
        {
            _settings = Services.Instance.Single<Settings>();
        }
    }
}