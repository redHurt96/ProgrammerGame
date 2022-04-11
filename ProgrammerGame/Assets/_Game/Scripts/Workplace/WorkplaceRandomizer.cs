using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Workplace
{
    public class WorkplaceRandomizer : MonoBehaviour
    {
        [SerializeField] private GameObject[] _variants;

        private void Start()
        {
            int number = Random.Range(0, _variants.Length);

            for (int i = 0; i < _variants.Length; i++)
            {
                if (i != number)
                    Destroy(_variants[i]);
            }

            Destroy(this);
        }
    }
}
