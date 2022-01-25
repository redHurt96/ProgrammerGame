using System;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public abstract class BaseUpgradeManager<TSelf> : Singleton<TSelf>, IUpgradeManager where TSelf : Singleton<TSelf>
    {
        public event Action Buyed;
        public bool CanBuy => Wallet.Instance.MoneyCount >= CalculatePrice() && _objectsManager.CanUpgrade;

        public int Level { get; private set; }
        private readonly IUpgradeObjectManager _objectsManager;
        private readonly AnimationCurve _pricesCurve;

        protected BaseUpgradeManager(IUpgradeObjectManager objectsManager, AnimationCurve pricesCurve)
        {
            _objectsManager = objectsManager;
            _pricesCurve = pricesCurve;
        }

        public void Buy()
        {
            Wallet.Instance.Spend(CalculatePrice());
            _objectsManager.Upgrade();
            Level++;
        }

        public int CalculatePrice() => (int)_pricesCurve.Evaluate(Level);
    }
}