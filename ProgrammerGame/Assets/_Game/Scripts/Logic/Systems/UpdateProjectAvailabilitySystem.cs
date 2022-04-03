using System.Linq;
using _Game.Configs;
using _Game.Logic.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class UpdateProjectAvailabilitySystem : BaseInitSystem
    {
        public override void Init()
        {
            foreach (ProjectData project in GameData.Instance.Projects) 
                project.DataUpdated += UpdateProjectDatas;
        }
        
        public override void Dispose()
        {
            foreach (ProjectData project in GameData.Instance.Projects) 
                project.DataUpdated += UpdateProjectDatas;
        }

        private void UpdateProjectDatas()
        {
            foreach (ProjectData project in GameData.Instance.Projects)
            {
                if (project.State != ProjectState.NotAvailable)
                    continue;

                ProjectSettings settings = Settings.Instance.ProjectsSettings
                    .First(x => x.Name == project.Name);

                ProjectData blockProject = GameData.Instance.Projects
                    .First(x => x.Name == settings.BlockProject.Name);

                if (blockProject.Level >= settings.OpenLevel)
                    project.SetAvailable();
            }
        }
    }
}