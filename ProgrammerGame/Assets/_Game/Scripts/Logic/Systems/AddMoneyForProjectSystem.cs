using System.Linq;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class AddMoneyForProjectSystem : BaseInitSystem
    {
        private GlobalEventsService _globalEvents;
        private GameData _gameData;

        public override void Init()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();
            
            _globalEvents.ProjectStarted += AddMoneyWhenProjectComplete;
        }

        public override void Dispose() => 
            _globalEvents.ProjectStarted -= AddMoneyWhenProjectComplete;

        private void AddMoneyWhenProjectComplete(ProjectData projectData)
        {
            RunProjectProcess process = _gameData.RunnedProjects
                .First(x => x.ProjectData == projectData);

            process.Finished += AddMoney;
        }

        private void AddMoney(RunProjectProcess process) => 
            _globalEvents.IntentToChangeMoney((int)process.ProjectData.Income);
    }
}