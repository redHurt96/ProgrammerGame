using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Project settings", menuName = "Game/Project settings", order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        public string Name;
        public Sprite Icon;

        public int OpenLevel = 0;
        public ProjectSettings BlockProject;

        public long Time;
        public int Price;
        public int Income;
    }
}