using System.Collections;
using _Game.Configs;
using _Game.GameServices;
using _Game.UI.Windows;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class TutorialWindow : BaseWindow
    {
        public TutorialStep Step => _step;

        [Header("Tutorial window")]
        [SerializeField] private TutorialStep _step;
        [SerializeField] private RectTransform _target;

        [Space]
        [SerializeField] private float _windowNonInteractableTime = 1f;

        private bool _isDestroyed;
        private bool _canClose;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_windowNonInteractableTime);

            _canClose = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _canClose)
                Close();
        }
    }
}