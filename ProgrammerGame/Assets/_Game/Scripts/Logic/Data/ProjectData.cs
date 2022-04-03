using System;

namespace _Game.Logic.Data
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
        public float Income;
        public float Price;
        public long TimeToFinish;

        //not for save
        public TimeSpan CurrentTimeToFinish;

        public float Progress => 1 - (float) (CurrentTimeToFinish.TotalSeconds / TimeToFinish);

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
            CurrentTimeToFinish = TimeSpan.FromSeconds(TimeToFinish - time);

            DataUpdated?.Invoke();
        }

        public void CompleteProcess()
        {
            CurrentTimeToFinish = TimeSpan.FromSeconds(TimeToFinish);

            DataUpdated?.Invoke();
        }
    }
}