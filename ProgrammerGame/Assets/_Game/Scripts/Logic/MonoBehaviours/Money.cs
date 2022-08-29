using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class Money : MonoBehaviour
    {
        public long Value;
        public Vector3 StartScale;

        private void Start()
        {
            StartScale = transform.localScale;
        }
    }
}