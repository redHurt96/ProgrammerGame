using RH.Utilities.SingletonAccess;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AP.ProgrammerGame.Logic
{
    public class Wallet : Singleton<Wallet>
    {
        public event Action CountChanged;

        public int MoneyCount => _moneys.Count;

        private List<GameObject> _moneys = new List<GameObject>();

        public void Add(int amount)
        {
            _moneys.AddRange(MoneySpawner.Instance.SpawnMoney(amount));
            CountChanged?.Invoke();
        }

        public void Spend(int amount)
        {
            if (_moneys.Count > amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    GameObject moneyObject = _moneys[0];
                    _moneys.RemoveAt(0);
                    Object.Destroy(moneyObject);
                }

                CountChanged?.Invoke();
            }
        }
    }
}