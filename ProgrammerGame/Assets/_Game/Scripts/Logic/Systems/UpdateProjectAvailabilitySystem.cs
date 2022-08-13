using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class UpdateProjectAvailabilitySystem : BaseInitSystem
    {
        private readonly Settings _settings;
        private readonly GameData _data;

        public UpdateProjectAvailabilitySystem()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
        }

        public override void Init()
        {
            foreach (ProjectData project in _data.SavableData.Projects) 
                project.MainDataUpdated += UpdateProjectMainDatas;
        }
        
        public override void Dispose()
        {
            foreach (ProjectData project in _data.SavableData.Projects) 
                project.MainDataUpdated += UpdateProjectMainDatas;
        }

        private void UpdateProjectMainDatas()
        {
            foreach (ProjectData project in _data.SavableData.Projects)
            {
                if (project.State != ProjectState.NotAvailable)
                    continue;

                ProjectSettings settings = _settings.ProjectsSettings
                    .First(x => x.Name == project.Name);

                ProjectData blockProject = _data.SavableData.Projects
                    .First(x => x.Name == settings.BlockProject.Name);

                if (blockProject.Level >= settings.OpenLevel)
                    project.SetAvailable();
            }
        }
    }
}