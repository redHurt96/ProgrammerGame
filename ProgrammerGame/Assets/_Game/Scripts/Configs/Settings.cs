using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/Settings", order = 0)]
    public class Settings : SingletonScriptableObject<Settings>
    {
        public GameObject MoneyPrefab;
        public AnimationCurve MoneyPerLevel;

        [Space]
        public AnimationCurve MoneyPerFurniture;
        public AnimationCurve MoneyPerComputer;
        public AnimationCurve MoneyPerDeveloper;

        [Space]
        public float MoneyRigidbodyRemoveTime = 3f;

        [Space]
        public GameObject TapFxPrefab;

        [Space]
        public int[] TargetLevels = {25, 50, 75, 100, 150, 200, 250, 300, 400, 500, 750, 1000};

        [Space]
        public ProjectSettings[] ProjectsSettings;

        public float MoneyForTapPercent;

        [Header("Start options")] 
        public long StartMoney;
    }
}