using System.Collections.Generic;
using System.Linq;
using _Game.Logic.MonoBehaviours;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class MoneyStorageSystem : BaseInitSystem
    {
        private List<Money> _moneys = new List<Money>();

        public override void Init()
        {
            GlobalEvents.MoneyCreated += Keep;
            GlobalEvents.MoneyCountChanged += RemoveIfAmountNegative;
        }

        public override void Dispose()
        {
            GlobalEvents.MoneyCreated -= Keep;
            GlobalEvents.MoneyCountChanged -= RemoveIfAmountNegative;
        }

        private void Keep(Money money) => _moneys.Add(money);

        private void RemoveIfAmountNegative(long amount)
        {
            if (amount > 0)
                return;

            Remove(amount);
        }

        private void Remove(long amount)
        {
            amount = -amount;
            _moneys.OrderBy(x => x.Value);

            while (amount > 0)
            {
                Money money = _moneys.FirstOrDefault(x => x.Value < amount);

                if (money == null)
                    break;

                _moneys.Remove(money);
                amount -= money.Value;

                Object.Destroy(money);
            }
        }
    }
}