using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Tutorial
{
    public class MoveUpScroll : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;

        private void Start() => 
            _scrollRect.verticalNormalizedPosition = 0;
    }
}