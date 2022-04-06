using System;
using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using RH.Utilities.SingletonAccess;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Services
{
    public class Apartment : Singleton<Apartment>
    {
        public int ProgrammersSpotCount => _programmerSpots.Count;
        
        private readonly Dictionary<string, GameObject> _programmerSpots = new Dictionary<string, GameObject>();
        private readonly List<GameObject> _rooms = new List<GameObject>();
        private readonly Dictionary<FurnitureSlotType, GameObject> _furnitures = new Dictionary<FurnitureSlotType, GameObject>();

        private Transform _apartmentParent => SceneObjects.Instance.HouseParent;

        public void AddFurniture(FurnitureSlot slot)
        {
            foreach (FurnitureSlotType replacingType in slot.ReplacingTypes)
            {
                if (!_furnitures.ContainsKey(replacingType))
                    throw new Exception($"There is no furniture with type {replacingType} to replace. Check your rooms settings");

                Object.Destroy(_furnitures[replacingType]);
                _furnitures.Remove(replacingType);
            }

            GameObject furniture = Object.Instantiate(slot.Furniture, _apartmentParent);
            //furniture.transform.localPosition = slot.Furniture.transform.position;
            _furnitures.Add(slot.Type, furniture);
        }

        public void AddRoom(RoomSettings room)
        {
            _rooms.Add(Object.Instantiate(room.Base, _apartmentParent));

            foreach (FurnitureSlot slot in room.DefaultFurniture) 
                AddFurniture(slot);

            foreach (ProgrammerSpot programmerSpot in room.ProgrammerSpots)
                _programmerSpots.Add(
                    programmerSpot.ProgrammerSettings.Name, 
                    Object.Instantiate(programmerSpot.Spot, _apartmentParent));
        }

        public bool ContainSpotFor(string programmerName) => 
            _programmerSpots.ContainsKey(programmerName);
    }
}