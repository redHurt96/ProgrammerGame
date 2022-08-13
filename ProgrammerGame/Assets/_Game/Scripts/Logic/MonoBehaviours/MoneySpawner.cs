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

        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private Coroutine _currentCoroutine;
        private Settings _settings;

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
            if (amount <= 0 && _currentCoroutine != null)
                return;

            List<Money> moneysPrefabs = _settings.GetMoneysPrefabsList(amount);

            _currentCoroutine = StartCoroutine(SpawnMoneyDelayed(moneysPrefabs));
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