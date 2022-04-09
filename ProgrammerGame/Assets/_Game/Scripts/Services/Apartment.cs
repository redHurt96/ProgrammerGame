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
        private readonly Dictionary<string, GameObject> _furniture = new Dictionary<string, GameObject>();

        private Transform _apartmentParent => SceneObjects.Instance.HouseParent;

        public void AddFurniture(FurnitureSlot slot)
        {
            foreach (string replacingType in slot.ReplacingTypes)
            {
                if (!_furniture.ContainsKey(replacingType))
                    throw new Exception($"There is no furniture with type {replacingType} to replace. Check your rooms settings");

                Object.Destroy(_furniture[replacingType]);
                _furniture.Remove(replacingType);
            }

            _furniture.Add(slot.Type, Object.Instantiate(slot.Furniture, _apartmentParent));
        }

        public void AddRoom(RoomSettings room)
        {
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