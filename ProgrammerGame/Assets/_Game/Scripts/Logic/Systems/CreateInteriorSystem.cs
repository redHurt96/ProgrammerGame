using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreateInteriorSystem : BaseInitSystem
    {
        private UpgradeData _interiorUpgradeData;

        private readonly GameDataPresenter _gameDataPresenter;

        public CreateInteriorSystem()
        {
            _gameDataPresenter = Services.Get<GameDataPresenter>();
        }

        public override void Init()
        {
            _interiorUpgradeData = _gameDataPresenter.GetUpgradeData(UpgradeType.Interior);

            CreateInteriors();

            _interiorUpgradeData.Upgraded += UpgradeInterior;
        }

        public override void Dispose() => 
            _interiorUpgradeData.Upgraded -= UpgradeInterior;

        private void CreateInteriors()
        {
            for (int i = 0; i < _interiorUpgradeData.Level; i++) 
                CreateInterior(i);
        }

        private void UpgradeInterior() => 
            CreateInterior(_interiorUpgradeData.Level - 1);

        private void CreateInterior(int number)
        {
            foreach (RoomSettings room in Settings.Instance.Rooms)
            {
                if (number < room.FurnitureForPurchase.Length)
                {
                    Apartment.Instance.AddFurniture(room.FurnitureForPurchase[number]);
                    return;
                }

                number -= room.FurnitureForPurchase.Length;
            }
        }
    }
}