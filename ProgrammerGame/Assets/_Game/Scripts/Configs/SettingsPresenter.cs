using System.Collections.Generic;
using System.Linq;
using _Game.Logic.MonoBehaviours;
using RH.Utilities.SingletonAccess;

namespace _Game.Configs
{
    public class SettingsPresenter : Singleton<SettingsPresenter>
    {
        public List<Money> GetMoneysPrefabsList(double amount)
        {
            List<Money> moneysPrefabs = new List<Money>();

            while (amount > 0)
            {
                Money prefab = GetMoneyResourceByValue(amount);

                if (prefab == null || moneysPrefabs.Count >= Settings.Instance.MaxMoneySpawnCount)
                    break;

                moneysPrefabs.Add(prefab);

                amount -= prefab.Value;
            }

            return moneysPrefabs;
        }

        private Money GetMoneyResourceByValue(double amount) =>
            Settings.Instance.MoneyPrefabs.LastOrDefault(x => x.Value <= amount);
    }
}