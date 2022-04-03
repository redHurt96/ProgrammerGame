using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Programmer settings", menuName = "Game/Programmer settings", order = 0)]
    public class ProgrammerSettings : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public ProjectSettings AutomatedProject;
        public long Price;
    }
}