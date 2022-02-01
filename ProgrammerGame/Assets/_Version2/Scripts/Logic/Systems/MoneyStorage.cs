using System;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
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

        private void Keep(GameObject money) => _moneys.Add(money);

        private void RemoveIfAmountNegative(int amount)
        {
            if (amount > 0)
                return;

            Remove(amount);
        }

        private void Remove(int amount)
        {
            var count = -amount;

            for (int i = 0; i < count; i++)
                Remove();
        }

        private void Remove()
        {
            try
            {
                var index = _moneys.Count - 1;
                GameObject money = _moneys[index];
                _moneys.RemoveAt(index);
                UnityEngine.Object.Destroy(money);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
        }
    }
}