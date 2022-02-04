using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace RH.Utilities.SimpleCi
{
    public static class Builder
    {
        static Builder()
        {
            if (!Directory.Exists(Path.Combine(Application.dataPath, "..", "Artifacts")))
                Directory.CreateDirectory(Path.Combine(Application.dataPath, "..", "Artifacts"));
        }

        [MenuItem("📦 Build/Android")]
        public static void ToAndroid()
        {
            BuildPipeline.BuildPlayer(
                new BuildPlayerOptions
                {
                    target = BuildTarget.Android,
                    locationPathName = "Artifacts/Game.apk",
                    scenes = GetActiveScenes()
                });
        }

        [MenuItem("📦 Build/📁 Show build folder")]
        private static void OpenBuildsFolder()
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() {
                FileName = Path.Combine(Application.dataPath, "..", "Artifacts"),
                UseShellExecute = true,
                Verb = "open"
            });
        }
        
        private static string[] GetActiveScenes()
        {
            List<string> scenes = new List<string>();

            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                    scenes.Add(scene.path);
            }

            return scenes.ToArray();
        }
    }
}