using System;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Programmers settings", menuName = "Game/Programmers settings", order = 0)]
    public class AllProgrammersSettings : ScriptableObject
    {
        public float BoostPerProgrammerLevel;
        public ProgrammerWorkplace[] Workplaces;
        public ProgrammerSettings[] Programmers;
        public FurnitureSlot[] Upgrades;

        [Serializable]
        public class ProgrammerWorkplace
        {
            public ProgrammerSettings ProgrammerSettings;
            public FurnitureSlot FurnitureSlot;
        }
    }
}