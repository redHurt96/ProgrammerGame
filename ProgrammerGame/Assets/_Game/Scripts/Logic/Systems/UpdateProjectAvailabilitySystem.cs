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
        private readonly GameData _gameData;

        public UpdateProjectAvailabilitySystem()
        {
            _settings = Services.Instance.Single<Settings>();
            _gameData = Services.Instance.Single<GameData>();
        }

        public override void Init()
        {
            foreach (ProjectData project in _gameData.SavableData.Projects) 
                project.MainDataUpdated += UpdateProjectMainDatas;
        }
        
        public override void Dispose()
        {
            foreach (ProjectData project in _gameData.SavableData.Projects) 
                project.MainDataUpdated += UpdateProjectMainDatas;
        }

        private void UpdateProjectMainDatas()
        {
            foreach (ProjectData project in _gameData.SavableData.Projects)
            {
                if (project.State != ProjectState.NotAvailable)
                    continue;

                ProjectSettings settings = _settings.ProjectsSettings
                    .First(x => x.Name == project.Name);

                ProjectData blockProject = _gameData.SavableData.Projects
                    .First(x => x.Name == settings.BlockProject.Name);

                if (blockProject.Level >= settings.OpenLevel)
                    project.SetAvailable();
            }
        }
    }
}