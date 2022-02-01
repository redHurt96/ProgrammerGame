using RH.Utilities.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AP.ProgrammerGame.Logic
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnZone;

        private GameObject _prefab => Settings.Instance.MoneyPrefab;
        private Transform _parent => SceneObjects.Instance.MoneyParentObject;

        private void Start() => 
            GlobalEvents.MoneyCountChanged += SpawnMoney;

        private void OnDestroy() => 
            GlobalEvents.MoneyCountChanged += SpawnMoney;

        private void SpawnMoney(int amount)
        {
            if (amount <= 0)
                return;

            for (int i = 0; i < amount; i++)
                Spawn();
        }

        private void Spawn()
        {
            Vector3 spawnPoint = transform.position.AddRandomInBox(_spawnZone);
            var money = Instantiate(_prefab, spawnPoint, Random.rotation, _parent);

            GlobalEvents.CreateMoney(money);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, .2f);
            Gizmos.DrawCube(transform.position, _spawnZone * 2);
        }
    }
}