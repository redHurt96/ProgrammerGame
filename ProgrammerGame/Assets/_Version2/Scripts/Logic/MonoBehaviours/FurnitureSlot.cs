using System;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    [Serializable]
    public class FurnitureSlot
    {
        public FurnitureSlotType[] ReplacingTypes;
        public FurnitureSlotType Type;
        public GameObject Furniture;
    }
}