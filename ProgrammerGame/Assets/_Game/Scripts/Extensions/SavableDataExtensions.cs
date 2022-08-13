using System.Linq;
using _Game.Configs;
using _Game.Data;

namespace _Game.Extensions
{
    public static class SavableDataExtensions
    {
        public static void Init(this SavableData savableData, Settings settings)
        {
            foreach (ProjectData project in savableData.Projects)
                project.projectSettings = settings.ProjectsSettings.First(x => x.Name == project.Name);
        }
    }
}