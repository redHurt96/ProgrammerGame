using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FurnitureSlot
    {
        public string Type => Furniture.name;
        public GameObject Furniture;
        public string[] ReplacingTypes;
    }
}