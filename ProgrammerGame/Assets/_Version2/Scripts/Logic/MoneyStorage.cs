using System;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class MoneyStorage : IDisposable
    {
        private List<GameObject> _moneys = new List<GameObject>();

        public MoneyStorage()
        {
            GlobalEvents.MoneyCreated += Keep;
            GlobalEvents.MoneyCountChanged += RemoveIfAmountNegative;
        }

        public void Dispose()
        {
            GlobalEvents.MoneyCreated -= Keep;
            GlobalEvents.MoneyCountChanged -= RemoveIfAmountNegative;
        }

        private void Keep(GameObject money) => 
            _moneys.Add(money);

        private void RemoveIfAmountNegative(float amount)
        {
            if (amount > 0)
                return;

            Remove(amount);
        }

        private void Remove(float amount)
        {
            var count = (int)amount;

            for (int i = 0; i < count; i++)
                Remove();
        }

        private void Remove()
        {
            GameObject money = _moneys[0];
            _moneys.RemoveAt(0);
            UnityEngine.Object.Destroy(money);
        }
    }
}