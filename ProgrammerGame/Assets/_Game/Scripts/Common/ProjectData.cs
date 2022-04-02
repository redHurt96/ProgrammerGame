using System;

namespace AP.ProgrammerGame
{
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
        public float Progress;

        public event Action DataUpdated;

        public void Buy()
        {
            if (Level == 0)
                State = ProjectState.Active;

            Level++;

            DataUpdated?.Invoke();
        }

        public void Run()
        {
            throw new Exception("There is no run logic");
        }

        public void SetAvailable()
        {
            State = ProjectState.NotPurchased;
            DataUpdated?.Invoke();
        }
    }

    public enum ProjectState
    {
        NotAvailable,
        NotPurchased,
        Active,
    }
}