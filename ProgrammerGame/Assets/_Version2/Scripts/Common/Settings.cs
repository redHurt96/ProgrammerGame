using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/V2/Settings", order = 0)]
    public class Settings : ScriptableObject
    {
        public GameObject MoneyPrefab;

        public static Settings Instance { get; private set; }

        public void CreateInstance()
        {
            Instance = this;
        }
    }
}