using System.Collections.Generic;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class MoneyStorageSystem : BaseInitSystem
    {
        private List<GameObject> _moneys = new List<GameObject>();

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

        private void Keep(GameObject money) => _moneys.Add(money);

        private void RemoveIfAmountNegative(long amount)
        {
            if (amount > 0)
                return;

            Remove(amount);
        }

        private void Remove(long amount)
        {
            var count = -amount;

            for (int i = 0; i < count; i++)
                Remove();
        }

        private void Remove()
        {
            int index = _moneys.Count - 1;
            GameObject money = _moneys[index];

            _moneys.RemoveAt(index);
            UnityEngine.Object.Destroy(money);
        }
    }
}