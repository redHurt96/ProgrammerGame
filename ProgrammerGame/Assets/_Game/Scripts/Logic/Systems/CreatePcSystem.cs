using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Services;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class CreatePcSystem : BaseInitSystem
    {
        private UpgradeData _pcUpgradeData;
        private UpgradeData _roomsUpgradeData;

        public override void Init()
        {
            _pcUpgradeData = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.PC);
            _roomsUpgradeData = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.House);

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

            for (int i = 0; i < _roomsUpgradeData.Level; i++) 
                CreatePc(i);
        }

        private void UpgradePc() => CreatePc(_pcUpgradeData.Level);

        private void CreatePc(int number) => 
            Apartment.Instance.AddFurniture(Settings.Instance.PcSettings.FurnitureForPurchase[number - 1]);
    }
}