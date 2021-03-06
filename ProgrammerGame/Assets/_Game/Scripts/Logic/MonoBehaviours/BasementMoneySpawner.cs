using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Logic.MonoBehaviours
{
    public class BasementMoneySpawner : MonoBehaviour
    {
        private Transform _transform;
        private List<Money> _existed = new List<Money>();

        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private void Start()
        {
            _transform = transform;

            EventsMediator.Instance.MoneyCountChanged += SpawnOrRemoveMoney;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            EventsMediator.Instance.MoneyCountChanged -= SpawnOrRemoveMoney;
        }

        private void SpawnOrRemoveMoney(double amount)
        {
            if (amount > 0)
            {
                if (_existed.Count < Settings.Instance.MaxBasementMoneysCount)
                    Spawn(amount);
            }
            else
                Remove(amount);
        }

        private void Spawn(double amount)
        {
            List<Money> moneysPrefabs = Settings.Instance.GetMoneysPrefabsList(amount);
            StartCoroutine(SpawnMoneyDelayed(moneysPrefabs));
        }

        private void Remove(double amount)
        {
            amount = -amount;
            _existed.OrderBy(x => x.Value);

            while (amount > 0)
            {
                var smallest = _existed.FirstOrDefault(x => x.Value < amount);

                if (smallest == null)
                    break;

                amount -= smallest.Value;
                _existed.Remove(smallest);

                Destroy(smallest.gameObject);
            }
        }

        private IEnumerator SpawnMoneyDelayed(List<Money> prefabs)
        {
            float spawnDelay = Settings.Instance.MoneySpawnTime / prefabs.Count;
            WaitForSeconds wait = new WaitForSeconds(spawnDelay);

            yield return new WaitForSeconds(Settings.Instance.MoneyBasementSpawnDelay);

            foreach (Money prefab in prefabs)
            {
                Spawn(prefab);

                yield return wait;
            }
        }

        private void Spawn(Money prefab)
        {
            Money money = Instantiate(prefab, _transform.position + Random.insideUnitSphere / 4f, Random.rotation, _parent);

            Vector3 direction = 
                _transform.right * Settings.Instance.MoneyBasementForce 
                + Random.insideUnitSphere * Settings.Instance.MoneyBasementRandomizeForce;

            money
                .GetComponent<Rigidbody>()
                .AddForce(direction);

            _existed.Add(money);
        }
    }
}