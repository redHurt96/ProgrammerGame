using System.Linq;

namespace AP.ProgrammerGame.Logic
{
    public class UpdateProjectAvailabilityDataSystem
    {
        public UpdateProjectAvailabilityDataSystem()
        {
            foreach (ProjectData project in GameData.Instance.Projects) 
                project.Purchased += UpdateProjectDatas;
        }

        private void UpdateProjectDatas()
        {
            foreach (ProjectData project in GameData.Instance.Projects)
            {
                ProjectSettings settings = Settings.Instance.ProjectsSettings
                    .First(x => x.Name == project.Name);
                
                if (settings.BlockProject == null || project.ProjectState != ProjectState.NotAvailable)
                    continue;
            }
        }
    }
}