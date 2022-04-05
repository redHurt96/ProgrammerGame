using System;

namespace _Game.Data
{
    [Serializable]
    public class UpgradeData
    {
        public event Action Upgraded;

        public UpgradeType Type;
        public int Level;

        public void Upgrade()
        {
            Level++;
            Upgraded?.Invoke();
        }
    }
}