using System;
using RH.Utilities.SingletonAccess;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class MoneySpawner : MonoBehaviourSingleton<MoneySpawner>
    {
        [SerializeField] private GameObject _moneyPrefab;

        private SpawnZone _spawnZone;

        public void AttachSpawnZone(SpawnZone spawnZone) => _spawnZone = spawnZone;

        public List<GameObject> SpawnMoney(int amount)
        {
            var moneys = new List<GameObject>();

            for (int i = 0; i < amount; i++)
                moneys.Add(SpawnMoney());

            return moneys;
        }

        private GameObject SpawnMoney() => _spawnZone.Instantiate(_moneyPrefab, transform);
    }
}