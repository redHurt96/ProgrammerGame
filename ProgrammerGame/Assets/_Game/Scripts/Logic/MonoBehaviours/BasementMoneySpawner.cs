using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Logic.MonoBehaviours
{
    public class BasementMoneySpawner : MonoBehaviour
    {
        private Transform _transform;
        private List<Money> _existed = new List<Money>();
        private GlobalEventsService _globalEvents;
        private Settings _settings;
        private SettingsPresenter _settingsPresenter;

        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private void Start()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _settings = Services.Instance.Single<Settings>();
            _settingsPresenter = Services.Instance.Single<SettingsPresenter>();

            _transform = transform;

            _globalEvents.MoneyCountChanged += SpawnOrRemoveMoney;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            _globalEvents.MoneyCountChanged -= SpawnOrRemoveMoney;
        }

        private void SpawnOrRemoveMoney(double amount)
        {
            if (amount > 0)
            {
                if (_existed.Count < _settings.MaxBasementMoneysCount)
                    Spawn(amount);
            }
            else
                Remove(amount);
        }

        private void Spawn(double amount)
        {
            List<Money> moneysPrefabs = _settingsPresenter.GetMoneysPrefabsList(amount);
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
            float spawnDelay = _settings.MoneySpawnTime / prefabs.Count;
            WaitForSeconds wait = new WaitForSeconds(spawnDelay);

            yield return new WaitForSeconds(_settings.MoneyBasementSpawnDelay);

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
                _transform.right * _settings.MoneyBasementForce 
                + Random.insideUnitSphere * _settings.MoneyBasementRandomizeForce;

            money
                .GetComponent<Rigidbody>()
                .AddForce(direction);

            _existed.Add(money);
        }
    }
}