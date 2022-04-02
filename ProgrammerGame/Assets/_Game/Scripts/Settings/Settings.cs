using System.Collections.Generic;
using AP.ProgrammerGame.UI;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame
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

        [Space]
        public float MoneyRigidbodyRemoveTime = 5f;

        [Space]
        public float BugMoveTime;
        public float BugMoveDelay;

        [Space]
        public GameObject TapFxPrefab;
        public CatchBugButton BugPrefab;

        [Space]
        public int[] TargetLevels = {25, 50, 75, 100, 150, 200, 250, 300, 400, 500, 750, 1000};

        [Space]
        public ProjectSettings[] ProjectsSettings;
    }
}