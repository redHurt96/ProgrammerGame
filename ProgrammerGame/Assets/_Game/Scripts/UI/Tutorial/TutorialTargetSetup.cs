using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Tutorial
{
    public class TutorialTargetSetup : MonoBehaviour
    {
        [SerializeField] private TutorialWindow _window;

        private WindowsManager _windowsManager;

        private void Start()
        {
            _windowsManager = Services.Get<WindowsManager>();

            Canvas canvasComponent = _window.Target.AddComponent<Canvas>();
            canvasComponent.overrideSorting = true;
            canvasComponent.sortingOrder = 7;
            _window.Target.AddComponent<GraphicRaycaster>();

            _window
                .Target
                .GetComponent<Button>()
                .onClick
                .AddListener(HideTutorialFromButton);

            _window.Closed += HideTutorial;
        }

        private void HideTutorialFromButton()
        {
            HideTutorial();

            _windowsManager.Hide(_window);
        }

        private void HideTutorial()
        {
            if (_window.Target.TryGetComponent(out GraphicRaycaster raycaster))
                Destroy(raycaster);
 
            if (_window.Target.TryGetComponent(out Canvas canvas))
                Destroy(canvas);

            _window
                .Target
                .GetComponent<Button>()
                .onClick
                .RemoveListener(HideTutorialFromButton);
        }
    }
}