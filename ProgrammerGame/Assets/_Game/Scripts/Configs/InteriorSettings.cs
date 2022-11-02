using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Interior settings", menuName = "Game/Interior settings", order = 0)]
    public class InteriorSettings : ScriptableObject
    {
        public FurnitureSlot2[] PcUpgrades => 
            FurnitureForPurchase
                .Where((t, i) => _pcUpgradesIndexes.Contains(i))
                .ToArray();
        
        public FurnitureSlot2[] InteriorUpgrades => 
            FurnitureForPurchase
                .Where((t, i) => _interiorUpgradesIndexes.Contains(i))
                .ToArray();
        
        public FurnitureSlot2[] HouseUpgrades => 
            FurnitureForPurchase
                .Where((t, i) => _houseUpgradesIndexes.Contains(i))
                .ToArray();

        public GameObject[] DefaultFurniture;
        public List<FurnitureSlot2> FurnitureForPurchase = new List<FurnitureSlot2>();
        
        [SerializeField] private PriceSettings _pcPriceSettings;
        [SerializeField] private PriceSettings _housePriceSettings;
        [SerializeField] private PriceSettings _interiorPriceSettings;
        [SerializeField] private int[] _pcUpgradesIndexes;
        [SerializeField] private int[] _interiorUpgradesIndexes;
        [SerializeField] private int[] _houseUpgradesIndexes;

        public double GetInteriorPrice(int forLevel) => 
            _interiorPriceSettings.GetPrice(forLevel);
        
        public double GetPcPrice(int forLevel) => 
            _pcPriceSettings.GetPrice(forLevel);

        public double GetHousePrice(int forLevel) => 
            _housePriceSettings.GetPrice(forLevel);
    }
}