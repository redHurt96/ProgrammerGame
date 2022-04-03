using UnityEngine;

namespace AP.ProgrammerGame
{
    [CreateAssetMenu(fileName = "Project settings", menuName = "Game/V2/Project settings", order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        public string Name;
        public Sprite Icon;

        public int OpenLevel = 0;
        public ProjectSettings BlockProject;

        public long Time;
    }
}