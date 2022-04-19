using RH.Utilities.Saving;

namespace _Game.Data
{
    public class PersistentData : ISavableData
    {
        public int Level;
        public long TotalEarnedMoney;
        public float MainBoost = 1f;

        public string Key => "Persistent";
    }
}