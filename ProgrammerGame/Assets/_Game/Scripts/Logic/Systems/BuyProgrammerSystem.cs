using System.Collections;
using System.Linq;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class BuyProgrammerSystem : BaseInitSystem
    {
        public override void Init()
        {
            foreach (string project in GameData.Instance.SavableData.AutoRunnedProjects)
                AutoRunProject(GameData.Instance.SavableData.Projects.Find(x => x.Name == project));

            GlobalEvents.BuyProgrammerIntent += BuyProgrammer;
        }

        public override void Dispose() => 
            GlobalEvents.BuyProgrammerIntent -= BuyProgrammer;

        private void BuyProgrammer(string forProject)
        {
            GameData.Instance.SavableData.AutoRunnedProjects.Add(forProject);
            AutoRunProject(GameData.Instance.SavableData.Projects.Find(x => x.Name == forProject));
        }

        private void AutoRunProject(ProjectData projectData)
        {
            var runnedProcess = GameData.Instance.RunnedProjects.Find(x => x.ProjectData == projectData);

            if (runnedProcess != null)
                AutoRunAfterFinish(runnedProcess);
            else
                AutoRun(projectData);
        }

        private void AutoRunAfterFinish(RunProjectProcess runnedProcess) => 
            runnedProcess.Finished += AutoRun;

        private void AutoRun(RunProjectProcess process) => 
            AutoRun(process.ProjectData);

        private void AutoRun(ProjectData projectData) => 
            CoroutineLauncher.Start(StartAutoRunProcess(projectData));

        private IEnumerator StartAutoRunProcess(ProjectData projectData)
        {
            while (Application.isPlaying)
            {
                GlobalEvents.IntentToRunProject(projectData);

                yield return new WaitUntil(
                    () => GameData.Instance.RunnedProjects.All(x => x.ProjectData != projectData));
            }
        }
    }
}