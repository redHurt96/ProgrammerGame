using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using AP.ProgrammerGame;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class MoneySpawner : MonoBehaviour
    {
        private Transform _transform;

        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private void Start()
        {
            _transform = transform;

            GlobalEvents.MoneyCountChanged += SpawnMoney;
        }

        private void OnDestroy() => 
            GlobalEvents.MoneyCountChanged -= SpawnMoney;

        private void SpawnMoney(long amount)
        {
            if (amount <= 0)
                return;

            List<Money> moneysPrefabs = SettingsPresenter.Instance.GetMoneysList(amount);

            StartCoroutine(SpawnMoneyDelayed(moneysPrefabs));
        }

        private IEnumerator SpawnMoneyDelayed(List<Money> prefabs)
        {
            float spawnDelay = Settings.Instance.MoneySpawnTime / prefabs.Count;
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
            money.GetComponent<Rigidbody>().AddForce(Vector3.down * Settings.Instance.MoneyFallForce);

            Destroy(money.gameObject, Settings.Instance.MoneyBasementSpawnDelay);
        }
    }
}