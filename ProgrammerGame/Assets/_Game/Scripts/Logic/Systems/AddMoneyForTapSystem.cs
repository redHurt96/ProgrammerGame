using System.Linq;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class AddMoneyForTapSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.OnCodingAccelerated += AddMoney;

        public override void Dispose() => 
            GlobalEvents.OnCodingAccelerated -= AddMoney;

        private void AddMoney()
        {
            double income = 0;

            foreach (ProjectData project in GameData.Instance.Projects.Where(x => x.State == ProjectState.Active))
                income += ((double)project.Income / project.Time * Settings.Instance.MoneyForTapPercent);

            GlobalEvents.IntentToChangeMoney((long)income);
        }
    }
}