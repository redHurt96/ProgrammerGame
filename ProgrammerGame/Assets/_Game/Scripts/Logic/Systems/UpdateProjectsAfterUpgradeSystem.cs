using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class UpdateProjectsAfterUpgradeSystem : BaseInitSystem
    {
        private readonly GlobalEventsService _globalEvents;
        private readonly GameData _gameData;

        public UpdateProjectsAfterUpgradeSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();
        }

        public override void Init() => 
            _globalEvents.OnUpgraded += UpdateProjects;

        public override void Dispose() => 
            _globalEvents.OnUpgraded -= UpdateProjects;

        private void UpdateProjects(UpgradeType upgradeType)
        {
            foreach (ProjectData project in _gameData.SavableData.Projects) 
                project.InvokeUpdateEvent();
        }
    }
}