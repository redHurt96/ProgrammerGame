using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class HouseManager : Singleton<HouseManager>, IUpgradeObjectManager
    {
        public House Current { get; private set; }
        public bool CanUpgrade => true;
        public int Level { get; private set; }

        private EnvironmentAssets _assets;
        private FurnitureManager _furnitureManager;

        public void Init(EnvironmentAssets assets, FurnitureManager furnitureManager)
        {
            _assets = assets;
            _furnitureManager = furnitureManager;

            SetHouse();
        }

        public void Upgrade()
        {
            Level++;
            Level %= _assets.Houses.Length;

            SetHouse();

            _furnitureManager.Set(Current);
        }

        private void SetHouse()
        {
            if (Current != null)
                Object.Destroy(Current.gameObject);

            Current = Object.Instantiate(_assets.Houses[Level]);
            Current.DisableAll();

            MoneySpawner.Instance.AttachSpawnZone(Current.SpawnZone);
        }
    }
}