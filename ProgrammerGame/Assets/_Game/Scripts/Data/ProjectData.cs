using System;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Data
{
    [Serializable]
    public class ProjectData
    {
        //for save
        public ProjectState State;
        public string Name;
        public int Level;

        //not for save
        public TimeSpan CurrentTimeToFinish;
        public ProjectSettings projectSettings;
        
        private readonly GameData _gameData;
        private readonly GameDataPresenter _gameDataPresenter;

        public double BaseIncome => projectSettings.GetIncome(Level);
        public long BaseTime => projectSettings.GetTime(Level);
        public double GetPrice(int count) => projectSettings.GetPrice(Level, count);

        public float Progress => Mathf.Clamp01(1 - (float) (CurrentTimeToFinish.TotalSeconds / Time));
        public long Time => (long) Mathf.Max(1,BaseTime / (1 + _gameDataPresenter.IncreaseSpeedTotalEffect) / _gameData.PersistentData.MainBoost);
        public double Income => (long) 
            (BaseIncome 
             * (1 + _gameDataPresenter.IncreaseMoneyTotalEffect) 
             * _gameData.PersistentData.MainBoost 
             * _gameData.DailyBonusData.Bonus);

        public event Action MainDataUpdated;
        public event Action TimeUpdated;
        public event Action DynamicDataUpdated;

        public ProjectData()
        {
            _gameData = Services.Instance.Single<GameData>();
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();

            projectSettings = Services.Instance.Single<Settings>()
                .ProjectsSettings
                .First(x => x.Name == Name);
        }
        
        public void Buy(int count)
        {
            if (Level == 0)
                State = ProjectState.Active;

            Level += count;

            InvokeUpdateEvent();
        }

        public void SetAvailable()
        {
            State = ProjectState.NotPurchased;

            InvokeUpdateEvent();
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

        public void InvokeUpdateEvent() => 
            MainDataUpdated?.Invoke();
    }
}