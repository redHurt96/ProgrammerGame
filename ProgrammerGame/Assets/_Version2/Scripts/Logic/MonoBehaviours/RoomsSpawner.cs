using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class RoomsSpawner : MonoBehaviourSingleton<RoomsSpawner>
    {
        public int AvailableRoomsCount => _roomsPositions.Length;

        [SerializeField] private Vector3[] _roomsPositions;
        [SerializeField] private GameObject _roomPrefab;

        private void Start() => GlobalEvents.BuyDeveloperCompleted += Spawn;
        private void OnDestroy() => GlobalEvents.BuyDeveloperCompleted -= Spawn;

        private void Spawn()
        {
            int index = GameData.Instance.PurchasedDevelopersCount - 1;
            GameObject room = Instantiate(_roomPrefab, SceneObjects.Instance.HouseParentObject);

            room.transform.localPosition = _roomsPositions[index];
        }
    }
}