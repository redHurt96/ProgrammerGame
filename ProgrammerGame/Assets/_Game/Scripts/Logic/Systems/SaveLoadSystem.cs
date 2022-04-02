namespace AP.ProgrammerGame.Logic
{
    public class SaveLoadSystem
    {
        public SaveLoadSystem() => CreateProjectsData();

        private void CreateProjectsData()
        {
            foreach (ProjectSettings projectSettings in Settings.Instance.ProjectsSettings)
            {
                GameData.Instance.Projects.Add(
                    new ProjectData
                    {
                        Name = projectSettings.Name
                    });
            }
        }
    }
}