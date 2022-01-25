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

            var furnitureManager = new FurnitureManager();
            var houseManager = new HouseManager();

            houseManager.Init(_environmentAssets, furnitureManager);
            furnitureManager.Set(houseManager.Current);

            new HouseUpgradeManager(HouseManager.Instance, _settings.HousePrices);
            new FurnitureUpgradeManager(FurnitureManager.Instance, _settings.FurniturePrices);
        }
    }
}