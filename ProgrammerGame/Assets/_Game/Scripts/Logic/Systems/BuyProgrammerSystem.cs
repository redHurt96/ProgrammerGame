using System.Collections;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class BuyProgrammerSystem : BaseInitSystem
    {
        private readonly GlobalEventsService _globalEvents;
        private readonly GameData _gameData;

        public BuyProgrammerSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();
        }

        public override void Init()
        {
            foreach (string project in _gameData.SavableData.AutoRunnedProjects)
                AutoRunProject(_gameData.SavableData.Projects.Find(x => x.Name == project));

            _globalEvents.BuyProgrammerIntent += BuyProgrammer;
        }

        public override void Dispose() => 
            _globalEvents.BuyProgrammerIntent -= BuyProgrammer;

        private void BuyProgrammer(string forProject)
        {
            _gameData.SavableData.AutoRunnedProjects.Add(forProject);
            AutoRunProject(_gameData.SavableData.Projects.Find(x => x.Name == forProject));
            _globalEvents.InvokeOnBuyProgrammerEvent();
        }

        private void AutoRunProject(ProjectData projectData)
        {
            var runnedProcess = _gameData.RunnedProjects.Find(x => x.ProjectData == projectData);

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
                _globalEvents.IntentToRunProject(projectData);

                yield return new WaitUntil(
                    () => _gameData.RunnedProjects.All(x => x.ProjectData != projectData));
            }
        }
    }
}