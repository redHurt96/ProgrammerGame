using System;
using RH.Utilities.SingletonAccess;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AP.ProgrammerGame.Logic
{
    public class MoneySpawner : MonoBehaviourSingleton<MoneySpawner>
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _moneysObjectsParent;
        [SerializeField] private Vector3 _spawnZone;

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
            Vector3 spawnPoint = _spawnPoint.position
                                 + new Vector3(
                                     Random.Range(-_spawnZone.x, _spawnZone.x),
                                     Random.Range(-_spawnZone.y, _spawnZone.y),
                                     Random.Range(-_spawnZone.z, _spawnZone.z));

            Debug.DrawLine(spawnPoint, spawnPoint + Vector3.down * 2, Color.green, 10f);
            return Instantiate(_moneyPrefab, spawnPoint, Random.rotation, _moneysObjectsParent);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, .2f);
            Gizmos.DrawCube(_spawnPoint.position, _spawnZone * 2);
        }
    }
}