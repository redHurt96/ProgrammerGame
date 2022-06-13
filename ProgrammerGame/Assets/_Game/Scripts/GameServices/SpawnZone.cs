using UnityEngine;

namespace _Game.Common
{
    public class SpawnZone : MonoBehaviour
    {
        [SerializeField] private float _radius;

        public Vector3 GetPoint() =>
            transform.position + Random.insideUnitSphere * _radius;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}