using System.Collections.Generic;
using System.Linq;
using _Game.Logic.MonoBehaviours;

namespace _Game.Configs
{
    public static class SettingsExtensions
    {
        public static List<Money> GetMoneysPrefabsList(this Settings settings, double amount)
        {
            List<Money> moneysPrefabs = new List<Money>();

            while (amount > 0)
            {
                Money prefab = GetMoneyResourceByValue(settings, amount);

                if (prefab == null || moneysPrefabs.Count >= settings.MaxMoneySpawnCount)
                    break;

                moneysPrefabs.Add(prefab);

                amount -= prefab.Value;
            }

            return moneysPrefabs;
        }

        private static Money GetMoneyResourceByValue(this Settings settings, double amount) =>
            settings.MoneyPrefabs.LastOrDefault(x => x.Value <= amount);
    }
}