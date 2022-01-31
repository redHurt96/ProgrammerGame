using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class HouseManager : Singleton<HouseManager>, IUpgradeObjectManager
    {
        public House Current { get; private set; }
        public bool CanUpgrade => true;

        private EnvironmentAssets _assets;
        private int _level = 0;

        public void Init(EnvironmentAssets assets)
        {
            _assets = assets;
            SetHouse();
        }

        public void Upgrade()
        {
            _level %= _assets.Houses.Length;
            SetHouse();
        }

        private void SetHouse()
        {
            if (Current != null)
                Object.Destroy(Current.gameObject);

            Current = Object.Instantiate(_assets.Houses[_level]);
            Current.DisableAll();

            MoneySpawner.Instance.AttachSpawnZone(Current.SpawnZone);
        }
    }
}