using System;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Data
{
    //TODO: не менять напрямую данные в ProjectData!!!
    //в таком виде они удобнее для сохранения, но ломают инвариант
    [Serializable]
    public class ProjectData
    {
        //for save
        public ProjectState State;
        public string Name;
        public int Level;

        //not for save
        [NonSerialized] public TimeSpan CurrentTimeToFinish;
        [NonSerialized] public ProjectSettings projectSettings;
        [NonSerialized] private float _speedBoost = 1f;

        private GameData _data => Services.Get<GameData>();
        private Settings _settings => Services.Get<Settings>();

        public double BaseIncome => projectSettings.GetIncome(Level);
        public float BaseTime => projectSettings.GetTime(Level);
        public double GetPrice(int count) => projectSettings.GetPrice(Level, count);

        public float Progress => Mathf.Clamp01(1 - (float) (CurrentTimeToFinish.TotalSeconds / Time));
        public float Time => 
            Mathf.Max(_settings.MinProjectTime,BaseTime / (1 + _data.SpeedTotalEffect()) / _data.PersistentData.MainBoost / _speedBoost);
        
        public double Income
        {
            get
            {
                var baseIncome = (long)
                    (BaseIncome
                     * (1 + _data.MoneyTotalEffect())
                     * _data.PersistentData.MainBoost
                     * _data.DailyBonusData.Bonus);

                if (_data.IsProjectAutoRunned(Name))
                    baseIncome = (long)(baseIncome * (1 + _data.GetProgrammerUpgradeData(Name).Level *
                        _settings.AllProgrammersSettings.BoostPerProgrammerLevel));

                return baseIncome;
            }
        }

        public event Action MainDataUpdated;
        public event Action TimeUpdated;
        public event Action DynamicDataUpdated;

        public void Buy(int count)
        {
            if (Level == 0)
                State = ProjectState.Active;

            Level += count;

            ForceUpdate();
        }

        public void SetAvailable()
        {
            State = ProjectState.NotPurchased;

            ForceUpdate();
        }

        public void SetTime(float time)
        {
            CurrentTimeToFinish = TimeSpan.FromSeconds(Time - time);

            TimeUpdated?.Invoke();
        }

        public void CompleteProcess()
        {
            CurrentTimeToFinish = TimeSpan.FromSeconds(Time);

            DynamicDataUpdated?.Invoke();
        }

        public void ForceUpdate() => 
            MainDataUpdated?.Invoke();

        public void ChangeSpeedBoost(float amount) => 
            _speedBoost = amount;
    }
}