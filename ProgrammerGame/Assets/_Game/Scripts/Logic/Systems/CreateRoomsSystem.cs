using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreateRoomsSystem : BaseInitSystem
    {
        private UpgradeData _roomsUpgradeData;

        private readonly Apartment _apartment;
        private readonly GameData _data;
        private readonly Settings _settings;

        public CreateRoomsSystem()
        {
            _apartment = Services.Get<Apartment>();
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
        }

        public override void Init()
        {
            _roomsUpgradeData = _data.GetUpgradeData(UpgradeType.House);

            CreateRooms();

            _roomsUpgradeData.Upgraded += UpgradeRooms;
        }

        public override void Dispose() => 
            _roomsUpgradeData.Upgraded -= UpgradeRooms;

        private void CreateRooms()
        {
            for (int i = 0; i < _roomsUpgradeData.Level + 1; i++) 
                CreateRoom(i);
        }

        private void UpgradeRooms() => 
            CreateRoom(_roomsUpgradeData.Level);

        private void CreateRoom(int number)
        {
            RoomSettings room = _settings.Rooms[number];

            _apartment.AddRoom(room);
        }
    }
}