using System.Linq;
using _Game.Logic.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class AddMoneyForProjectSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.ProjectStarted += AddMoneyWhenProjectComplete;

        public override void Dispose() => 
            GlobalEvents.ProjectStarted -= AddMoneyWhenProjectComplete;

        private void AddMoneyWhenProjectComplete(ProjectData projectData)
        {
            RunProjectProcess process = GameData.Instance.RunnedProjects
                .First(x => x.ProjectData == projectData);

            process.Finished += AddMoney;
        }

        private void AddMoney(RunProjectProcess process) => 
            GlobalEvents.IntentChangeMoney((int)process.ProjectData.Income);
    }
}