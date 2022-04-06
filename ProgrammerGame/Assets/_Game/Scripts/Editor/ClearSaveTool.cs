using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    public static class ClearSaveTool
    {
        [MenuItem("🎮 Game/🧹 Clear save")]
        public static void ClearSave()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}