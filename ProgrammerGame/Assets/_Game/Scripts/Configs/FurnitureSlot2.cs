using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FurnitureSlot2
    {
        public GameObject[] FurnitureToStand;
        public string[] FurnitureToRemove;

        public static FurnitureSlot2 CreateFrom(FurnitureSlot slot) =>
            new FurnitureSlot2
            {
                FurnitureToStand = new[] {slot.Furniture},
                FurnitureToRemove = slot.ReplacingTypes,
            };
    }
}