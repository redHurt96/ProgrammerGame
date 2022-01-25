using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class FurnitureManager : Singleton<FurnitureManager>, IUpgradeObjectManager
    {
        public bool CanUpgrade => Level < _currentHouse.Furnitures.Length - 1;
        public int Level { get; private set; }

        private House _currentHouse;

        public void Set(House house)
        {
            Level = 0;
            _currentHouse = house;
            CreateCurrentFurniture();
        }

        public void Upgrade()
        {
            if (CanUpgrade)
            {
                Level++;
                CreateCurrentFurniture();
            }
        }

        private void CreateCurrentFurniture() =>
            _currentHouse.Furnitures[Level].Enable();
    }
}