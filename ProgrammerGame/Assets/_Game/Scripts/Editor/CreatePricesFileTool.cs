using _Game.GameServices;
using UnityEditor;

namespace _Game.Scripts.Editor
{
    public static class CreatePricesFileTool
    {
        [MenuItem("🎮 Game/💲 Prices/📁 Create file")]
        public static void CreateFile()
        {
            var service = new SaveLoadPricesService();
            service.Save();
        }
    }
}