using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FurnitureSlot
    {
        public FurnitureSlotType Type;
        public FurnitureSlotType[] ReplacingTypes;
        public GameObject Furniture;
    }
}