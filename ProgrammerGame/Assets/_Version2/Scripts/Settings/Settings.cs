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
        public AnimationCurve MoneyPerFurniture;
        public AnimationCurve MoneyPerComputer;
        public AnimationCurve MoneyPerDeveloper;

        [Space]
        public float AccelerationPerFurniture = .05f;

        public float LevelPerFurniture = 1f;
        public float LevelPerPc = 3f;
        public float LevelPerDeveloper = 10f;
    }
}