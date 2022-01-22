using RH.Utilities.SingletonAccess;
using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class MoneySpawner : MonoBehaviourSingleton<MoneySpawner>
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _moneysObjectsParent;
        [SerializeField] private float _spawnZoneRadius;

        [SerializeField] private GameObject _moneyPrefab;

        public List<GameObject> SpawnMoney(int amount)
        {
            var moneys = new List<GameObject>();

            for (int i = 0; i < amount; i++)
                moneys.Add(SpawnMoney());

            return moneys;
        }

        private GameObject SpawnMoney()
        {
            Vector3 spawnPoint = _spawnPoint.position + Random.insideUnitSphere * _spawnZoneRadius;
            return Instantiate(_moneyPrefab, spawnPoint, Random.rotation, _moneysObjectsParent);
        }
    }
}