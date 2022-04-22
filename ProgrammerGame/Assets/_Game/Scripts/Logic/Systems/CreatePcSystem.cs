using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreatePcSystem : BaseInitSystem
    {
        private UpgradeData _pcUpgradeData;
        private readonly Apartment _apartment;
        private readonly Settings _settings;
        private readonly GameDataPresenter _gameDataPresenter;

        public CreatePcSystem()
        {
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
            _settings = Services.Instance.Single<Settings>();
            _apartment = Services.Instance.Single<Apartment>();
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
            PcSettings pcSettings = _settings.PcSettings;

            foreach (FurnitureSlot slot in pcSettings.DefaultFurniture) 
                _apartment.AddFurniture(slot);

            for (int i = 0; i < _pcUpgradeData.Level; i++)
                _apartment.AddFurniture(pcSettings.FurnitureForPurchase[i]);
        }

        private void UpgradePc() => 
            CreatePc(_pcUpgradeData.Level);

        private void CreatePc(int number) => 
            _apartment.AddFurniture(_settings.PcSettings.FurnitureForPurchase[number - 1]);
    }
}