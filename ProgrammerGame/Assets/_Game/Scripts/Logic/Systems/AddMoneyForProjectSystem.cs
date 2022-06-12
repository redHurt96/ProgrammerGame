using System.Linq;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class AddMoneyForProjectSystem : BaseInitSystem
    {
        public override void Init() => 
            EventsMediator.Instance.ProjectStarted += AddMoneyWhenProjectComplete;

        public override void Dispose() => 
            EventsMediator.Instance.ProjectStarted -= AddMoneyWhenProjectComplete;

        private void AddMoneyWhenProjectComplete(ProjectData projectData)
        {
            RunProjectProcess process = GameData.Instance.RunnedProjects
                .First(x => x.ProjectData == projectData);

            process.Finished += AddMoney;
        }

        private void AddMoney(RunProjectProcess process) => 
            EventsMediator.Instance.IntentToChangeMoney((int)process.ProjectData.Income);
    }
}