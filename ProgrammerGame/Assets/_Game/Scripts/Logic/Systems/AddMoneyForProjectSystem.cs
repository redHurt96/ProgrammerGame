using System.Linq;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class AddMoneyForProjectSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.Instance.ProjectStarted += AddMoneyWhenProjectComplete;

        public override void Dispose() => 
            GlobalEvents.Instance.ProjectStarted -= AddMoneyWhenProjectComplete;

        private void AddMoneyWhenProjectComplete(ProjectData projectData)
        {
            RunProjectProcess process = GameData.Instance.RunnedProjects
                .First(x => x.ProjectData == projectData);

            process.Finished += AddMoney;
        }

        private void AddMoney(RunProjectProcess process) => 
            GlobalEvents.Instance.IntentToChangeMoney((int)process.ProjectData.Income);
    }
}