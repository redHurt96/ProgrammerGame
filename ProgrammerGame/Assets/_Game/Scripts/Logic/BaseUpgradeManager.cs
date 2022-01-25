using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public abstract class BaseUpgradeManager<TSelf> : Singleton<TSelf>, IUpgradeManager where TSelf : Singleton<TSelf>
    {
        public bool CanBuy => Wallet.Instance.MoneyCount >= CalculatePrice() && _objectsManager.CanUpgrade;

        private int _level;
        private readonly IUpgradeObjectManager _objectsManager;
        private readonly AnimationCurve _pricesCurve;

        public BaseUpgradeManager(IUpgradeObjectManager objectsManager, AnimationCurve pricesCurve)
        {
            _objectsManager = objectsManager;
            _pricesCurve = pricesCurve;
        }

        public void Buy()
        {
            Wallet.Instance.Spend(CalculatePrice());
            _objectsManager.Upgrade();
        }

        public int CalculatePrice() => (int)_pricesCurve.Evaluate(_level);
    }
}