using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class CreateRoomsSystem : BaseInitSystem
    {
        private UpgradeData _roomsUpgradeData;

        public override void Init()
        {
            _roomsUpgradeData = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.House);

            CreateRooms();

            _roomsUpgradeData.Upgraded += UpgradeRooms;
        }

        public override void Dispose()
        {
            _roomsUpgradeData.Upgraded -= UpgradeRooms;
        }

        private void CreateRooms()
        {
            for (int i = 0; i < _roomsUpgradeData.Level + 1; i++) 
                CreateRoom(i);
        }

        private void UpgradeRooms() => 
            CreateRoom(_roomsUpgradeData.Level);

        private void CreateRoom(int number)
        {
            RoomSettings room = Settings.Instance.Rooms[number];

            Apartment.Instance.AddRoom(room);
        }
    }
}