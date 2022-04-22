using System.Collections.Generic;
using System.Linq;
using _Game.Logic.MonoBehaviours;
using RH.Utilities.ServiceLocator;

namespace _Game.Configs
{
    public class SettingsPresenter : IService
    {
        private readonly Settings _settings;

        public SettingsPresenter()
        {
            _settings = Services.Instance.Single<Settings>();
        }

        public List<Money> GetMoneysPrefabsList(double amount)
        {
            List<Money> moneysPrefabs = new List<Money>();

            while (amount > 0)
            {
                Money prefab = GetMoneyResourceByValue(amount);

                if (prefab == null || moneysPrefabs.Count >= _settings.MaxMoneySpawnCount)
                    break;

                moneysPrefabs.Add(prefab);

                amount -= prefab.Value;
            }

            return moneysPrefabs;
        }

        private Money GetMoneyResourceByValue(double amount) =>
            _settings.MoneyPrefabs.LastOrDefault(x => x.Value <= amount);
    }
}