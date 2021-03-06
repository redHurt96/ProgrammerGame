using System.Collections.Generic;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Interior settings", menuName = "Game/Interior settings", order = 0)]
    public class InteriorSettings : ScriptableObject
    {
        public GameObject[] DefaultFurniture;
        public List<FurnitureSlot2> FurnitureForPurchase = new List<FurnitureSlot2>();
        
        [SerializeField] private PriceSettings _priceSettings;

        public double GetPrice(int forLevel) => 
            _priceSettings.GetPrice(forLevel);
    }
}