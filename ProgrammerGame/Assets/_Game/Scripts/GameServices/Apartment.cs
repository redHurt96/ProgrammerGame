using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.Saving;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.GameServices
{
    public class Apartment : IService
    {
        public int ProgrammersSpotCount => _programmerSpots.Count;

        private readonly Dictionary<string, GameObject> _programmerSpots = new Dictionary<string, GameObject>();
        private readonly Dictionary<string, GameObject> _furniture = new Dictionary<string, GameObject>();

        private Transform ApartmentRoot => SceneObjects.Instance.HouseRoot;

        public void AddFurniture(FurnitureSlot2 slot)
        {
            foreach (string replacingType in slot.FurnitureToRemove)
            {
                if (!_furniture.ContainsKey(replacingType))
                    throw new Exception($"There is no furniture with type {replacingType} to replace. Check your rooms settings");

                Object.Destroy(_furniture[replacingType]);
                _furniture.Remove(replacingType);
            }

            GameObject furniture = Object.Instantiate(slot.Furniture, ApartmentRoot);
            _furniture.Add(slot.Name, furniture);

            if (GameData.Instance.GameState == GameState.Play)
                EventsMediator.Instance.PerformOnFurnitureSpawned(furniture.transform.position);
        }

        public void AddProgrammer(string projectName, FurnitureSlot slot)
        {
            string replacingType = slot.ReplacingTypes[0];

            if (_programmerSpots[replacingType] == null)
                throw new Exception($"There is no furniture with type {replacingType} to replace. Check your rooms settings");

            GameObject replacingObject = _programmerSpots[replacingType];

            foreach (Transform child in slot.Furniture.transform) 
                CreateSubObject(child);

            Object.Destroy(replacingObject);

            if (GameData.Instance.GameState == GameState.Play)
                EventsMediator.Instance.PerformOnFurnitureSpawned(_furniture.Last().Value.transform.position);

            void CreateSubObject(Transform child)
            {
                var spotObject = Object.Instantiate(
                        child,
                        replacingObject.transform.position,
                        replacingObject.transform.rotation,
                        ApartmentRoot)
                    .gameObject;

                spotObject.name = $"{projectName}_{child.name}";

                _furniture.Add(spotObject.name,
                    spotObject);
            }
        }

        public void AddProgrammerUpgrade(string projectName, FurnitureSlot slot)
        {
            foreach (string replacingType in slot.ReplacingTypes)
            {
                var fullName = $"{projectName}_{replacingType}";

                if (!_furniture.ContainsKey(fullName))
                    throw new Exception($"There is no furniture with type {fullName} to replace. Check your rooms settings");

                Object.Destroy(_furniture[fullName]);
                _furniture.Remove(fullName);
            }

            Transform origin = _furniture.First(x => x.Key.Contains(projectName)).Value.transform;

            var spotObject = Object.Instantiate(
                    slot.Furniture,
                    origin.position,
                    origin.rotation,
                    ApartmentRoot)
                .gameObject;

            spotObject.name = $"{projectName}_{slot.Furniture.name}";

            _furniture.Add(spotObject.name,
                spotObject);
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

            _furniture.Add(slot.Name, Object.Instantiate(slot.Furniture, position, rotation, ApartmentRoot));
        }

        public bool ContainSpotFor(string programmerName) => 
            _programmerSpots.ContainsKey(programmerName);
    }
}