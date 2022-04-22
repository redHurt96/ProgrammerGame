using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class RunProjectSystem : BaseInitSystem
    {
        public RunProjectSystem()
        {
        }

        private List<RunProjectProcess> _processes => _gameData.RunnedProjects;

        public override void Init() => 
            _globalEvents.RunProjectIntent += RunProject;

        public override void Dispose() => 
            _globalEvents.RunProjectIntent -= RunProject;

        private void RunProject(ProjectData projectData)
        {
            RunProjectProcess projectProcess = new RunProjectProcess(projectData);

            if (_processes.Any(x => x.ProjectData == projectData))
                return;

            _processes.Add(projectProcess);

            _globalEvents.RunProject(projectData);

            projectProcess.Run();
            projectProcess.Finished += ClearRunnedProjectFromData;
        }

        private void ClearRunnedProjectFromData(RunProjectProcess runProjectProcess) => 
            _gameData.RunnedProjects.Remove(runProjectProcess);
    }
}