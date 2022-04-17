using System;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Programmers settings", menuName = "Game/Programmers settings", order = 0)]
    public class AllProgrammersSettings : ScriptableObject
    {
        public ProgrammerWorkplace[] Workplaces;
        public ProgrammerSettings[] Programmers;

        [Serializable]
        public class ProgrammerWorkplace
        {
            public ProgrammerSettings ProgrammerSettings;
            public FurnitureSlot FurnitureSlot;
        }
    }
}