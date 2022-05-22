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
        
        private TutorialSettings _tutorialSettings;

        public bool HasShown { get; private set; }

        protected override void PerformBeforeOpen()
        {
            _tutorialSettings = Services.Get<TutorialSettings>();

            _tutorialSettings.Background.SetActive(true);
        }

        protected override void PerformBeforeClose()
        {
            HasShown = true;

            _tutorialSettings.Background.SetActive(false);
        }
    }
}