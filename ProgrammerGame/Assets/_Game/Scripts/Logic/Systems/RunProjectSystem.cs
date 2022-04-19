using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class RunProjectSystem : BaseInitSystem
    {
        private List<RunProjectProcess> _processes => GameData.Instance.RunnedProjects;

        public override void Init() => 
            GlobalEvents.Instance.RunProjectIntent += RunProject;

        public override void Dispose() => 
            GlobalEvents.Instance.RunProjectIntent -= RunProject;

        private void RunProject(ProjectData projectData)
        {
            RunProjectProcess projectProcess = new RunProjectProcess(projectData);

            if (_processes.Any(x => x.ProjectData == projectData))
                return;

            _processes.Add(projectProcess);

            GlobalEvents.Instance.RunProject(projectData);

            projectProcess.Run();
            projectProcess.Finished += ClearRunnedProjectFromData;
        }

        private void ClearRunnedProjectFromData(RunProjectProcess runProjectProcess) => 
            GameData.Instance.RunnedProjects.Remove(runProjectProcess);
    }
}