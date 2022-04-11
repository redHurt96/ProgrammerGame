using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    public static class ClearSaveTool
    {
        [MenuItem("🎮 Game/🧹 Clear/💾 Save")]
        public static void ClearSave()
        {
            PlayerPrefs.DeleteKey("Save");
            PlayerPrefs.Save();

            UnityEngine.Debug.Log("Saving cleared");
        }

        [MenuItem("🎮 Game/🧹 Clear/🚀 Main boost")]
        public static void ClearMainBoost()
        {
            PlayerPrefs.DeleteKey("Boost");
            PlayerPrefs.Save(); 

            UnityEngine.Debug.Log("Main boost cleared");
        }

        [MenuItem("🎮 Game/🧹 Clear/⚠ All")]
        public static void ClearAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            UnityEngine.Debug.Log("All saved data cleared");
        }
    }
}