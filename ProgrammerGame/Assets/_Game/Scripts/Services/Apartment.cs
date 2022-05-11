using System;
using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.SingletonAccess;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.GameServices
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

            GameObject furniture = Object.Instantiate(slot.Furniture, _apartmentParent);
            _furniture.Add(slot.Type, furniture);

            if (GameData.Instance.GameState == GameState.Play)
                GlobalEvents.Instance.PerformOnFurnitureSpawned(furniture.transform.position);
        }

        public void AddProgrammer(FurnitureSlot slot)
        {
            string replacingType = slot.ReplacingTypes[0];

            if (_programmerSpots[replacingType] == null)
                throw new Exception($"There is no furniture with type {replacingType} to replace. Check your rooms settings");

            GameObject replacingObject = _programmerSpots[replacingType];

            GameObject programmer = Object.Instantiate(
                slot.Furniture, 
                replacingObject.transform.position, 
                replacingObject.transform.rotation, 
                _apartmentParent);
            _furniture.Add(slot.Type, 
                programmer);

            Object.Destroy(replacingObject);

            if (GameData.Instance.GameState == GameState.Play)
                GlobalEvents.Instance.PerformOnFurnitureSpawned(programmer.transform.position);
        }

        public void AddMainCharacter(FurnitureSlot slot)
        {
            string replacingType = slot.ReplacingTypes[0];

            if (_furniture[replacingType] == null)
                throw new Exception($"There is no furniture with type {replacingType} to replace. Check your rooms settings");

            GameObject replacingObject = _furniture[replacingType];
            Vector3 position = replacingObject.transform.position;
            Quaternion rotation = replacingObject.transform.rotation;

            Object.Destroy(replacingObject);

            _furniture.Add(slot.Type, Object.Instantiate(slot.Furniture, position, rotation, _apartmentParent));
        }

        public void AddRoom(RoomSettings room)
        {
            foreach (FurnitureSlot slot in room.DefaultFurniture) 
                AddFurniture(slot);

            foreach (ProgrammerSpot programmerSpot in room.ProgrammerSpots)
                _programmerSpots.Add(
                    programmerSpot.ProgrammerSettings.name, 
                    Object.Instantiate(programmerSpot.Spot, _apartmentParent));
        }

        public bool ContainSpotFor(string programmerName) => 
            _programmerSpots.ContainsKey(programmerName);
    }
}