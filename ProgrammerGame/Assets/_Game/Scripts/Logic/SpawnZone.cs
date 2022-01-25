using UnityEngine;
using Random = UnityEngine.Random;

namespace AP.ProgrammerGame.Logic
{
    public class SpawnZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _spawnZone;

        public GameObject Instantiate(GameObject prefab, Transform toParent)
        {
            Vector3 spawnPoint = transform.position
                     + new Vector3(
                         Random.Range(-_spawnZone.x, _spawnZone.x),
                         Random.Range(-_spawnZone.y, _spawnZone.y),
                         Random.Range(-_spawnZone.z, _spawnZone.z));

            return Instantiate(prefab, spawnPoint, Random.rotation, toParent);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1f, 0f, 0f, .2f);
            Gizmos.DrawCube(transform.position, _spawnZone * 2);
        }
    }
}