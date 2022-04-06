using System;
using _Game.Common;
using _Game.Configs;
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

        public long BaseIncome => projectSettings.GetIncome(Level);
        public long Price => projectSettings.GetPrice(Level);
        public long BaseTime => projectSettings.GetTime(Level);

        public float Progress => Mathf.Clamp01(1 - (float) (CurrentTimeToFinish.TotalSeconds / Time));
        public long Time => (long) (BaseTime / (1 + GameDataPresenter.Instance.IncreaseSpeedTotalEffect));
        public long Income => (long) (BaseIncome * (1 + GameDataPresenter.Instance.IncreaseMoneyTotalEffect));

        public event Action DataUpdated;

        public void Buy()
        {
            if (Level == 0)
                State = ProjectState.Active;

            Level++;

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

            InvokeUpdateEvent();
        }

        public void CompleteProcess()
        {
            CurrentTimeToFinish = TimeSpan.FromSeconds(Time);

            InvokeUpdateEvent();
        }

        public void InvokeUpdateEvent() => 
            DataUpdated?.Invoke();
    }
}