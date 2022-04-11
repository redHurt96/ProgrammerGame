using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    public static class ClearSaveTool
    {
        [MenuItem("🎮 Game/🧹 Clear save")]
        public static void ClearSave()
        {
            PlayerPrefs.DeleteKey("Save");
            PlayerPrefs.Save();
        }
        
        [MenuItem("🎮 Game/🧹🚀 Clear main boost")]
        public static void ClearMainBoost()
        {
            PlayerPrefs.DeleteKey("Boost");
            PlayerPrefs.Save();
        }
        
        [MenuItem("🎮 Game/🧹⚠ Clear all")]
        public static void ClearAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}