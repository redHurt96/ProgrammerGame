using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FurnitureSlot
    {
        public string Type;
        public string[] ReplacingTypes;
        public GameObject Furniture;
    }
}