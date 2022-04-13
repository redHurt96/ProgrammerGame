using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class UpdateProjectAvailabilitySystem : BaseInitSystem
    {
        public override void Init()
        {
            foreach (ProjectData project in GameData.Instance.SavableData.Projects) 
                project.MainDataUpdated += UpdateProjectMainDatas;
        }
        
        public override void Dispose()
        {
            foreach (ProjectData project in GameData.Instance.SavableData.Projects) 
                project.MainDataUpdated += UpdateProjectMainDatas;
        }

        private void UpdateProjectMainDatas()
        {
            foreach (ProjectData project in GameData.Instance.SavableData.Projects)
            {
                if (project.State != ProjectState.NotAvailable)
                    continue;

                ProjectSettings settings = Settings.Instance.ProjectsSettings
                    .First(x => x.Name == project.Name);

                ProjectData blockProject = GameData.Instance.SavableData.Projects
                    .First(x => x.Name == settings.BlockProject.Name);

                if (blockProject.Level >= settings.OpenLevel)
                    project.SetAvailable();
            }
        }
    }
}