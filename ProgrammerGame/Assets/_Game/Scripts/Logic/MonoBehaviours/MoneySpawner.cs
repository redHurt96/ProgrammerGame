using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
using RH.Utilities.Extensions;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnZone;

        private Dictionary<long, Money> Prefabs;
        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private void Start()
        {
            Prefabs = Settings.Instance.MoneyPrefabs.ToDictionary(x => x.Value, y => y);

            GlobalEvents.MoneyCountChanged += SpawnMoney;
        }

        private void OnDestroy() => 
            GlobalEvents.MoneyCountChanged -= SpawnMoney;

        private void SpawnMoney(long amount)
        {
            if (amount <= 0)
                return;

            while (amount > 0)
            {
                Money prefab = Prefabs.Last(x => x.Key <= amount).Value;

                Spawn(prefab);

                amount -= prefab.Value;
            }
        }

        private void Spawn(Money prefab)
        {
            Vector3 spawnPoint = transform.position.AddRandomInBox(_spawnZone);
            Money money = Instantiate(prefab, spawnPoint, Random.rotation, _parent);

            GlobalEvents.CreateMoney(money);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, .2f);
            Gizmos.DrawCube(transform.position, _spawnZone * 2);
        }
    }
}