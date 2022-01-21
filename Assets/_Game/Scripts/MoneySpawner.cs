using RH.HyperCasualUtilities.GlobalEventsSystem;
using UnityEngine;

namespace AP.ProgrammerGame
{
    public class MoneySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _moneysObjectsParent;
        [SerializeField] private Vector3 _spawnZone;

        [SerializeField] private GameObject _moneyPrefab;

        private void Start() => GlobalEvents.Subscribe(EventsNames.CODE_WRITTEN, SpawnMoney);
        private void OnDestroy() => GlobalEvents.Unsubscribe(EventsNames.CODE_WRITTEN, SpawnMoney);

        private void SpawnMoney()
        {
            Vector3 spawnPoint = _spawnPoint.position + 
                new Vector3(
                    Random.Range(-_spawnZone.x, _spawnZone.x), 
                    Random.Range(-_spawnZone.y, _spawnZone.y), 
                    Random.Range(-_spawnZone.z, _spawnZone.z));

            GameObject money = Instantiate(_moneyPrefab, spawnPoint, Random.rotation, _moneysObjectsParent);
        }
    }

    public class Wallet
    {
        
    }
}