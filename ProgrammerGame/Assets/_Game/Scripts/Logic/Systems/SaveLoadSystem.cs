namespace AP.ProgrammerGame.Logic
{
    public class SaveLoadSystem
    {
        public SaveLoadSystem() => CreateProjectsData();

        private void CreateProjectsData()
        {
            foreach (ProjectSettings projectSettings in Settings.Instance.ProjectsSettings)
            {
                var projectData = new ProjectData();
                projectData.Name = projectSettings.Name;

                if (projectSettings.OpenLevel > 0)
                    projectData.State = ProjectState.NotAvailable;
                else
                    projectData.State = ProjectState.NotPurchased;

                GameData.Instance.Projects.Add(projectData);
            }
        }
    }
}