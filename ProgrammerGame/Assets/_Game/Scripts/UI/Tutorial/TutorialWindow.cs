using _Game.Tutorial;
using _Game.UI.Windows;
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

        public bool HasShown { get; private set; }

        protected override void PerformBeforeClose() => 
            HasShown = true;
    }
}