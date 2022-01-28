using System;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class House : MonoBehaviour
    {
        [Serializable]
        public class FurnitureSlot
        {
            public FurnitureSlotType Type;
            public GameObject Furniture;
        }

        public enum FurnitureSlotType
        {
            Bed,
            PC,
            Other
        }
    }
}