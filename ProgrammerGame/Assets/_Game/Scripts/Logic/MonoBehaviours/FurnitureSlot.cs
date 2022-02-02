using System;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    [Serializable]
    public class FurnitureSlot
    {
        public FurnitureSlotType[] ReplacingTypes;
        public FurnitureSlotType Type;
        public GameObject Furniture;
    }
}