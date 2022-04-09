using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FurnitureSlot
    {
        public string Type;
        public GameObject Furniture;
        public string[] ReplacingTypes;
    }
}