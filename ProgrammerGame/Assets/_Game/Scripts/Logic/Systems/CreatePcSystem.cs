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

        public override void Init()
        {
            _pcUpgradeData = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.PC);

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
        }

        private void UpgradePc() => 
            CreatePc(_pcUpgradeData.Level);

        private void CreatePc(int number) => 
            Apartment.Instance.AddFurniture(Settings.Instance.PcSettings.FurnitureForPurchase[number - 1]);
    }
}