using System;

namespace AP.ProgrammerGame
{
    [Serializable]
    public class ProjectData
    {
        //for save
        public ProjectState ProjectState;
        public string Name;
        public int Level;
        public float Income;
        public float Price;

        //not for save
        public TimeSpan TimeToFinish;
        public float Progress;

        public event Action ProgressUpdated;
        public event Action Finished;
        public event Action Purchased;
    }

    public enum ProjectState
    {
        NotAvailable,
        NotPurchased,
        Active,
    }
}