using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FurnitureSlot
    {
        public string Name => Furniture.name;
        public GameObject Furniture;
        public string[] ReplacingTypes;
    }
}