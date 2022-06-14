using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CreateInteriorSystem : BaseInitSystem
    {
        private UpgradeData _interiorUpgradeData;

        private readonly Apartment _apartment;
        private readonly Settings _settings;
        private readonly GameData _data;

        public CreateInteriorSystem()
        {
            _apartment = Services.Get<Apartment>();
            _settings = Services.Get<Settings>();
            _data = Services.Get<GameData>();
        }
        
        public override void Init()
        {
            _interiorUpgradeData = _data.GetUpgradeData(UpgradeType.Interior);

            CreateDefaultInteriors();
            CreatePurchasedInteriors();

            _interiorUpgradeData.Upgraded += UpgradeInterior;
        }

        public override void Dispose() => 
            _interiorUpgradeData.Upgraded -= UpgradeInterior;

        private void CreateDefaultInteriors()
        {
            foreach (GameObject furniture in _settings.Interior.DefaultFurniture) 
                _apartment.AddFurniture(furniture);
        }

        private void CreatePurchasedInteriors()
        {
            for (int i = 0; i < _interiorUpgradeData.Level; i++) 
                CreateInterior(i);
        }

        private void UpgradeInterior() => 
            CreateInterior(_interiorUpgradeData.Level - 1);

        private void CreateInterior(int number) => 
            _apartment.AddFurniture(_settings.Interior.FurnitureForPurchase[number]);
    }
}