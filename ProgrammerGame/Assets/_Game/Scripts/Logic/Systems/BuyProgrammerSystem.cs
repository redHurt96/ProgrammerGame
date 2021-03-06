using System.Collections;
using System.Linq;
using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class BuyProgrammerSystem : BaseInitSystem
    {
        public override void Init()
        {
            foreach (ProgrammerUpgradeData upgradeData in GameData.Instance.SavableData.AutoRunnedProjects)
                AutoRunProject(GameData.Instance.SavableData.Projects.Find(x => x.Name == upgradeData.ProjectName));

            EventsMediator.Instance.BuyProgrammerIntent += BuyProgrammer;
        }

        public override void Dispose() => 
            EventsMediator.Instance.BuyProgrammerIntent -= BuyProgrammer;

        private void BuyProgrammer(string forProject)
        {
            GameData.Instance.SavableData.AutoRunnedProjects.Add(new ProgrammerUpgradeData(forProject));
            AutoRunProject(GameData.Instance.SavableData.Projects.Find(x => x.Name == forProject));
            EventsMediator.Instance.InvokeOnBuyProgrammerEvent();
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
                EventsMediator.Instance.IntentToRunProject(projectData);

                yield return new WaitUntil(
                    () => GameData.Instance.RunnedProjects.All(x => x.ProjectData != projectData));
            }
        }
    }
}