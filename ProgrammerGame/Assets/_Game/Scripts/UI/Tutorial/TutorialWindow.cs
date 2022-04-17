using System.Collections;
using _Game.Configs;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class TutorialWindow : MonoBehaviour
    {
        public TutorialStep Step => _step;

        [SerializeField] private TutorialStep _step;

        [Space]
        [SerializeField] private float _windowNonInteractableTime = 1f;
        [SerializeField] private float _windowLifeTime = 5f;

        private bool _isDestroyed;
        private bool _canClose;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_windowNonInteractableTime);

            _canClose = true;

            yield return new WaitForSeconds(_windowLifeTime);

            Destroy();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _canClose)
                Destroy();
        }

        public void Enable() => 
            gameObject.SetActive(true);

        private void Destroy()
        {
            if (_isDestroyed)
                return;

            _isDestroyed = true;

            Destroy(gameObject);
        }
    }
}