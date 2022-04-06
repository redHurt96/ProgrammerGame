using System.Linq;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

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
            float income = 0;

            foreach (ProjectData project in GameData.Instance.Projects.Where(x => x.State == ProjectState.Active))
                income += Mathf.Max((float)project.Income / project.Time * Settings.Instance.MoneyForTapPercent, 1f);

            GlobalEvents.IntentToChangeMoney((long)income);
        }
    }
}