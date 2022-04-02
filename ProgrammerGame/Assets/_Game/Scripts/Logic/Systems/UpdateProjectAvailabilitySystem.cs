using System.Linq;

namespace AP.ProgrammerGame.Logic
{
    public class UpdateProjectAvailabilitySystem
    {
        public UpdateProjectAvailabilitySystem()
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