using System;
using _Game.Common;
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
        public long Income;
        public long Price;
        public long BaseTime;

        //not for save
        public TimeSpan CurrentTimeToFinish;

        public float Progress => Mathf.Clamp01(1 - (float) (CurrentTimeToFinish.TotalSeconds / BaseTime));
        public long Time => Time / (1 + GameDataPresenter.Instance.IncreaseSpeedTotalEffect);

        public event Action DataUpdated;

        public void Buy()
        {
            if (Level == 0)
                State = ProjectState.Active;

            Level++;

            DataUpdated?.Invoke();
        }

        public void SetAvailable()
        {
            State = ProjectState.NotPurchased;

            DataUpdated?.Invoke();
        }

        public void SetTime(float time)
        {
            CurrentTimeToFinish = TimeSpan.FromSeconds(BaseTime - time);

            DataUpdated?.Invoke();
        }

        public void CompleteProcess()
        {
            CurrentTimeToFinish = TimeSpan.FromSeconds(BaseTime);

            DataUpdated?.Invoke();
        }
    }
}