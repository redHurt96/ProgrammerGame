using System;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
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
        public TimeSpan CurrentTimeToFinish;
        public ProjectSettings projectSettings;

        public double BaseIncome => projectSettings.GetIncome(Level);
        public long BaseTime => projectSettings.GetTime(Level);
        public double GetPrice(int count) => projectSettings.GetPrice(Level, count);

        public float Progress => Mathf.Clamp01(1 - (float) (CurrentTimeToFinish.TotalSeconds / Time));
        public long Time => (long) Mathf.Max(1,BaseTime / (1 + GameData.Instance.IncreaseSpeedTotalEffect) / GameData.Instance.PersistentData.MainBoost);
        public double Income => (long) 
            (BaseIncome 
             * (1 + GameData.Instance.IncreaseMoneyTotalEffect) 
             * GameData.Instance.PersistentData.MainBoost 
             * GameData.Instance.DailyBonusData.Bonus);

        public event Action MainDataUpdated;
        public event Action TimeUpdated;
        public event Action DynamicDataUpdated;

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