using System.Collections;
using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class MoneySpawner : MonoBehaviour
    {
        private Transform _transform;
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

            _globalEvents.MoneyCountChanged += SpawnMoney;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();

            _globalEvents.MoneyCountChanged -= SpawnMoney;
        }

        private void SpawnMoney(double amount)
        {
            if (amount <= 0)
                return;

            List<Money> moneysPrefabs = _settingsPresenter.GetMoneysPrefabsList(amount);

            StartCoroutine(SpawnMoneyDelayed(moneysPrefabs));
        }

        private IEnumerator SpawnMoneyDelayed(List<Money> prefabs)
        {
            float spawnDelay = _settings.MoneySpawnTime / prefabs.Count;
            WaitForSeconds wait = new WaitForSeconds(spawnDelay);

            foreach (Money prefab in prefabs)
            {
                Spawn(prefab);

                yield return wait;
            }
        }

        private void Spawn(Money prefab)
        {
            Vector3 position = _transform.position + Random.insideUnitSphere / 10f;
            Money money = Instantiate(prefab, position, Random.rotation, _parent);

            money.GetComponent<Collider>().isTrigger = true;
            money.GetComponent<Rigidbody>().AddForce(Vector3.down * _settings.MoneyFallForce);

            Destroy(money.gameObject, _settings.MoneyBasementSpawnDelay);
        }
    }
}