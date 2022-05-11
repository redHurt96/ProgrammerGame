﻿using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreatePcSystem : BaseInitSystem
    {
        private UpgradeData _pcUpgradeData;
        private readonly GameDataPresenter _gameDataPresenter;

        public CreatePcSystem()
        {
            _gameDataPresenter = Services.Get<GameDataPresenter>();
        }

        public override void Init()
        {
            _pcUpgradeData = _gameDataPresenter.GetUpgradeData(UpgradeType.PC);

            CreatePcs();

            _pcUpgradeData.Upgraded += UpgradePc;
        }

        public override void Dispose() => 
            _pcUpgradeData.Upgraded -= UpgradePc;

        private void CreatePcs()
        {
            PcSettings pcSettings = Settings.Instance.PcSettings;

            foreach (FurnitureSlot slot in pcSettings.DefaultFurniture) 
                Apartment.Instance.AddFurniture(slot);

            for (int i = 0; i < _pcUpgradeData.Level; i++)
                Apartment.Instance.AddFurniture(pcSettings.FurnitureForPurchase[i]);
        }

        private void UpgradePc() => 
            CreatePc(_pcUpgradeData.Level);

        private void CreatePc(int number) => 
            Apartment.Instance.AddFurniture(Settings.Instance.PcSettings.FurnitureForPurchase[number - 1]);
    }
}