﻿using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class BuyUpgradeSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.Instance.BuyUpgradeIntent += BuyUpgrade;

        public override void Dispose() => 
            GlobalEvents.Instance.BuyUpgradeIntent -= BuyUpgrade;

        private void BuyUpgrade(UpgradeType type, double price)
        {
            GlobalEvents.Instance.IntentToChangeMoney(-price);
            GameDataPresenter.Instance.GetUpgradeData(type).Upgrade();
            GlobalEvents.Instance.InvokeAfterUpgradeEvent(type);
        }
    }
}