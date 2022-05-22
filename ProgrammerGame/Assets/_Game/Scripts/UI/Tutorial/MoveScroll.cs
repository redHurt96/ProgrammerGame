using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Tutorial
{
    public class MoveScroll : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private float _verticalNormalizedPosition = 1f;

        private void Start() => 
            _scrollRect.verticalNormalizedPosition = _verticalNormalizedPosition;
    }
}