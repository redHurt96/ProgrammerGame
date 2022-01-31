using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/V2/Settings", order = 0)]
    public class Settings : SingletonScriptableObject<Settings>
    {
        public GameObject MoneyPrefab;
        public AnimationCurve MoneyPerLevel;

        [Space]
        public AnimationCurve FurniturePrices;
        public AnimationCurve PcPrices;

        public float LevelPerFurniture;
        public float LevelPerHouse;
    }
}