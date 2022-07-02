using System;
using RH.Utilities;
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
        public bool IsProgrammersTabUnlocked;
        public bool IsUpgradesTabUnlocked;
        public bool IsBoostTabUnlocked;

        [NonSerialized]
        public CachedValue<float> AddendBoost;

        public string Key => "Persistent";
    }
}