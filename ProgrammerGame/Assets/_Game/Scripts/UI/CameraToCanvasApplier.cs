using _Game.Common;
using UnityEngine;

namespace _Game.UI
{
    public class CameraToCanvasApplier : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        private void Start()
        {
            _canvas.worldCamera = SceneObjects.Instance.Camera;
            Destroy(this);
        }
    }
}