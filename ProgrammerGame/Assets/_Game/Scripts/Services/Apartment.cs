using System;
using System.Collections.Generic;
using _Game.Configs;
using RH.Utilities.SingletonAccess;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Services
{
    public class Apartment : Singleton<Apartment>
    {
        private readonly List<GameObject> _rooms = new List<GameObject>();
        private readonly Dictionary<FurnitureSlotType, GameObject> _furnitures = new Dictionary<FurnitureSlotType, GameObject>();

        public void AddFurniture(FurnitureSlot slot)
        {
            foreach (FurnitureSlotType replacingType in slot.ReplacingTypes)
            {
                if (!_furnitures.ContainsKey(replacingType))
                    throw new Exception(
                        $"There is no furniture with type {replacingType} to replace. Check your rooms settings");

                Object.Destroy(_furnitures[replacingType]);
                _furnitures.Remove(replacingType);
            }

            GameObject furniture = Object.Instantiate(slot.Furniture);
            _furnitures.Add(slot.Type, furniture);
        }

        public void AddRoom(RoomSettings room) => 
            _rooms.Add(Object.Instantiate(room.Base));
    }
}