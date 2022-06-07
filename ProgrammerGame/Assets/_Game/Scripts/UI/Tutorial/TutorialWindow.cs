using System;
using System.Collections;
using _Game.Tutorial;
using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Tutorial
{
    public class TutorialWindow : BaseWindow
    {
        public event Action Closed;
        public TutorialStep Step => _step;
        public GameObject Target => _target;

        [Header("Tutorial window")]
        [SerializeField] private TutorialStep _step;
        [SerializeField] private GameObject _target;
        [SerializeField] private RectTransform _hand;
        [SerializeField] private Text _tapToSkipText;

        private TutorialSettings _tutorialSettings;

        private static WaitForSeconds _canManualCloseDelay = new WaitForSeconds(1.5f);
        private bool _canManualClose;

        protected override void PerformBeforeOpen()
        {
            _tutorialSettings = Services.Get<TutorialSettings>();

            _tutorialSettings.Background.SetActive(true);

            _hand.parent = Target.transform;
            _hand.anchoredPosition = Vector3.zero;
        }

        protected override void PerformBeforeClose()
        {
            _tutorialSettings.Background.SetActive(false);

            Destroy(_hand.gameObject);

            Closed?.Invoke();
        }

        private IEnumerator Start()
        {
            yield return _canManualCloseDelay;

            _canManualClose = true;
            _tapToSkipText.enabled = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _canManualClose)
                Close();
        }
    }
}