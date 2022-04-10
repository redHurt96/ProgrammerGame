using _Game.Common;
using _Game.Configs;
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

        private void AddMoney() => 
            GlobalEvents.IntentToChangeMoney( (long) Mathf.Max(1, GameDataPresenter.Instance.IncomePerSec * Settings.Instance.MoneyForTapPercent));
    }
}