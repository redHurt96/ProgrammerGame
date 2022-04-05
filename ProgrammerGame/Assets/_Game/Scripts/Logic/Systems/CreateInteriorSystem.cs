using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Services;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class CreateInteriorSystem : BaseInitSystem
    {
        private UpgradeData _roomsUpgradeData;
        private UpgradeData _interiorUpgradeData;

        public override void Init()
        {
            _interiorUpgradeData = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.Interior);
            _roomsUpgradeData = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.House);

            CreateInteriors();

            _interiorUpgradeData.Upgraded += UpgradeInterior;
        }

        public override void Dispose() => 
            _interiorUpgradeData.Upgraded -= UpgradeInterior;

        private void CreateInteriors()
        {
            for (int i = 0; i < _roomsUpgradeData.Level + 1; i++) 
                CreateInterior(i);
        }

        private void UpgradeInterior() => 
            CreateInterior(_interiorUpgradeData.Level);

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