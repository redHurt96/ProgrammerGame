using System;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class FurnitureStorage : IDisposable
    {
        private readonly Dictionary<FurnitureSlotType, GameObject> _furnitures = new Dictionary<FurnitureSlotType, GameObject>();

        public FurnitureStorage() => 
            GlobalEvents.FurnitureCreated += AddFurniture;

        public void Dispose() => 
            GlobalEvents.FurnitureCreated -= AddFurniture;

        private void AddFurniture(FurnitureSlotType type, GameObject furniture) => 
            _furnitures.Add(type, furniture);
    }
}