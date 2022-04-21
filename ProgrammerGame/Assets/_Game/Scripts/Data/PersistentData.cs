using System;
using RH.Utilities.Saving;

namespace _Game.Data
{
    [Serializable]
    public class PersistentData : ISavableData
    {
        public int Level;
        public double TotalEarnedMoney;
        public float MainBoost = 1f;
        public TutorialData TutorialData = new TutorialData();

        public string Key => "Persistent";
    }
}