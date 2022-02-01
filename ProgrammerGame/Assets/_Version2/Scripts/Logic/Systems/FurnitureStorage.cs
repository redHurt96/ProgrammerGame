using RH.Utilities.SingletonAccess;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class FurnitureStorage : Singleton<FurnitureStorage>
    {
        private readonly Dictionary<FurnitureSlotType, GameObject> _furnitures = new Dictionary<FurnitureSlotType, GameObject>();

        public FurnitureStorage() =>
            GlobalEvents.FurnitureCreated += AddFurniture;

        protected override void PrepareToDestroy() =>
            GlobalEvents.FurnitureCreated -= AddFurniture;

        public void RemoveFurnitures(FurnitureSlotType[] types)
        {
            foreach (FurnitureSlotType type in types)
                RemoveFurnitureIfContains(type);
        }

        private void AddFurniture(FurnitureSlotType type, GameObject furniture) =>
            _furnitures.Add(type, furniture);

        private void RemoveFurnitureIfContains(FurnitureSlotType type)
        {
            if (_furnitures.ContainsKey(type))
            {
                Object.Destroy(_furnitures[type]);
                _furnitures.Remove(type);
            }
        }
    }
}