using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class FurnitureManager : Singleton<FurnitureManager>, IUpgradeObjectManager
    {
        public bool CanUpgrade => CurrentLevel < _currentHouse.Furnitures.Length - 1;
        public int CurrentLevel { get; private set; }

        private House _currentHouse;

        public void Set(House house, int level)
        {
            CurrentLevel = level;
            _currentHouse = house;
            CreateCurrentFurniture();
        }

        public void Upgrade()
        {
            if (CanUpgrade)
            {
                CurrentLevel++;
                CreateCurrentFurniture();
            }
        }

        private void CreateCurrentFurniture() =>
            _currentHouse.Furnitures[CurrentLevel].Enable();
    }
}