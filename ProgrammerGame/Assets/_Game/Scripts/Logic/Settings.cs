using UnityEngine;

namespace AP.ProgrammerGame
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/Settings", order = 0)]
    public class Settings : ScriptableObject
    {
        public static Settings Instance { get; private set; }

        public int MoneyForCode = 1;
        public int MoneyForBug = 10;

        public void CreateInstance()
        {
            Instance = this;
        }
    }
}