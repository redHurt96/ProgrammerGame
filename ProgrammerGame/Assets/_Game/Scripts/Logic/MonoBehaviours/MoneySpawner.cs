using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using RH.Utilities.Attributes;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class MoneySpawner : MonoBehaviour
    {
        private Transform _transform;

        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private Coroutine _currentCoroutine;
        private Settings _settings;

        [SerializeField, ReadOnly] private int _count;
        [SerializeField, ReadOnly] private int _poolSize;

        private readonly MoneyPool _pool = new MoneyPool();
        private readonly List<Money> _existed = new List<Money>();

        private void Start()
        {
            _settings = Services.Get<Settings>();

            _transform = transform;

            EventsMediator.Instance.MoneyCountChanged += SpawnMoney;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();

            EventsMediator.Instance.MoneyCountChanged -= SpawnMoney;
        }

        private void SpawnMoney(double amount)
        {
            if (amount <= 0)
            {
                Remove((long)amount);
            }
            else if (_currentCoroutine == null)
            {
                List<Money> moneysPrefabs = _settings.GetMoneysPrefabsList(amount);

                _currentCoroutine = StartCoroutine(SpawnMoneyDelayed(moneysPrefabs));
            }

            _count = _existed.Count;
            _poolSize = _pool.Size;
        }

        private void Remove(long amount)
        {
            amount = -amount;
            
            IOrderedEnumerable<Money> orderedMoneys = _existed.OrderBy(x => x.Value);

            while (amount > 0)
            {
                Money smallest = orderedMoneys.FirstOrDefault(x => x.Value < amount);

                if (smallest == null)
                    break;

                amount -= smallest.Value;
                
                _existed.Remove(smallest);
                _pool.Put(smallest);
            }
        }

        private IEnumerator SpawnMoneyDelayed(List<Money> prefabs)
        {
            float spawnDelay = _settings.MoneySpawnTime / prefabs.Count;
            WaitForSeconds wait = new WaitForSeconds(spawnDelay);

            foreach (Money prefab in prefabs)
            {
                if (_existed.Count >= _settings.MaxBasementMoneysCount)
                    RemoveOldMoney();
                
                Spawn(prefab);

                yield return wait;
            }

            _currentCoroutine = null;
        }

        private void RemoveOldMoney()
        {
            _pool.Put(_existed[0]);
            _existed.RemoveAt(0);
        }

        private void Spawn(Money prefab)
        {
            Vector3 position = _transform.position + Random.insideUnitSphere * _settings.MoneySpawnRandomPosition;
            Money money = _pool.Get(prefab);
            Transform moneyTransform = money.transform;
            
            moneyTransform.position = position;
            moneyTransform.rotation = Random.rotation;
            moneyTransform.SetParent(_parent);

            money
                .GetComponent<Rigidbody>()
                .AddForce(Vector3.down * _settings.MoneyFallForce);
            
            _existed.Add(money);
        }
    }
}