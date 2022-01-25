using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private EnvironmentAssets _environmentAssets;

        private void Start()
        {
            _settings.CreateInstance();
            new Wallet();

            new HouseManager().Init(_environmentAssets);
            new FurnitureManager().Set(HouseManager.Instance.Current, 0);

            new HouseUpgradeManager(HouseManager.Instance, _settings.HousePrices);
            new FurnitureUpgradeManager(FurnitureManager.Instance, _settings.FurniturePrices);
        }
    }
}