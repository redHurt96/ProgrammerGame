using System.Collections.Generic;
using System.Linq;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class RunProjectSystem : BaseInitSystem
    {
        private List<RunProjectProcess> _processes => GameData.Instance.RunnedProjects;

        public override void Init() => 
            GlobalEvents.RunProjectIntent += RunProject;

        public override void Dispose() => 
            GlobalEvents.RunProjectIntent -= RunProject;

        private void RunProject(ProjectData projectData)
        {
            RunProjectProcess projectProcess = new RunProjectProcess(projectData);

            if (_processes.Any(x => x.ProjectData == projectData))
                return;

            _processes.Add(projectProcess);

            GlobalEvents.RunProject(projectData);

            projectProcess.Run();
            projectProcess.Finished += ClearRunnedProjectFromData;
        }

        private void ClearRunnedProjectFromData(RunProjectProcess runProjectProcess) => 
            GameData.Instance.RunnedProjects.Remove(runProjectProcess);
    }
}