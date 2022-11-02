using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreateHouseSystem : BaseInitSystem
    {
        private UpgradeData _houseUpgradeData;

        private readonly Apartment _apartment;
        private readonly Settings _settings;
        private readonly GameData _data;

        public CreateHouseSystem()
        {
            _apartment = Services.Get<Apartment>();
            _settings = Services.Get<Settings>();
            _data = Services.Get<GameData>();
        }
        
        public override void Init()
        {
            _houseUpgradeData = _data.GetUpgradeData(UpgradeType.House);

            CreatePurchasedInteriors();

            _houseUpgradeData.Upgraded += UpgradeHouse;
        }

        public override void Dispose() => 
            _houseUpgradeData.Upgraded -= UpgradeHouse;

        private void CreatePurchasedInteriors()
        {
            for (int i = 0; i < _houseUpgradeData.Level; i++) 
                CreateInterior(i);
        }

        private void UpgradeHouse() => 
            CreateInterior(_houseUpgradeData.Level - 1);

        private void CreateInterior(int number) => 
            _apartment.AddFurniture(_settings.Interior.HouseUpgrades[number]);
    }
}