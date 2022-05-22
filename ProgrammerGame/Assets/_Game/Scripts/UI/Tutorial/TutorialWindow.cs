using _Game.Tutorial;
using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class TutorialWindow : BaseWindow
    {
        public TutorialStep Step => _step;
        public GameObject Target => _target;

        [Header("Tutorial window")]
        [SerializeField] private TutorialStep _step;
        [SerializeField] private GameObject _target;
        [SerializeField] private RectTransform _hand;

        private TutorialSettings _tutorialSettings;

        public bool HasShown { get; private set; }

        protected override void PerformBeforeOpen()
        {
            _tutorialSettings = Services.Get<TutorialSettings>();

            _tutorialSettings.Background.SetActive(true);

            _hand.parent = Target.transform;
            _hand.anchoredPosition = Vector3.zero;
        }

        protected override void PerformBeforeClose()
        {
            HasShown = true;

            _tutorialSettings.Background.SetActive(false);

            Destroy(_hand.gameObject);
        }
    }
}