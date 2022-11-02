using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CreatePCSystem : BaseInitSystem
    {
        private UpgradeData _pcUpgradeData;

        private readonly Apartment _apartment;
        private readonly Settings _settings;
        private readonly GameData _data;

        public CreatePCSystem()
        {
            _apartment = Services.Get<Apartment>();
            _settings = Services.Get<Settings>();
            _data = Services.Get<GameData>();
        }
        
        public override void Init()
        {
            _pcUpgradeData = _data.GetUpgradeData(UpgradeType.PC);

            CreatePurchasedInteriors();

            _pcUpgradeData.Upgraded += UpgradePC;
        }

        public override void Dispose() => 
            _pcUpgradeData.Upgraded -= UpgradePC;

        private void CreatePurchasedInteriors()
        {
            for (int i = 0; i < _pcUpgradeData.Level; i++) 
                CreateInterior(i);
        }

        private void UpgradePC() => 
            CreateInterior(_pcUpgradeData.Level - 1);

        private void CreateInterior(int number) => 
            _apartment.AddFurniture(_settings.Interior.PcUpgrades[number]);
    }
}