using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using _Game.UI.Tutorial;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Game.Tutorial
{
    public class TutorialEvents : Singleton<TutorialEvents>
    {
        private readonly WindowsManager _windowsManager;

        public TutorialEvents() => 
            _windowsManager = Services.Get<WindowsManager>();

        private readonly Dictionary<TutorialStep, UnityAction> _actions = new Dictionary<TutorialStep, UnityAction>();

        public void CreateActionFrom(TutorialWindow window) => 
            _actions.Add(window.Step, () => ShowTutorial(window));

        public void InvokeEvent(TutorialStep name)
        {
            if (_actions.ContainsKey(name))
            {
                _actions[name]();

                GameData.Instance.PersistentData.TutorialData.Steps.Add(name);

                GlobalEvents.Instance.InvokeOnTutorialStepReceiveEvent();
            }
        }

        private void ShowTutorial(TutorialWindow window)
        {
            _windowsManager.Show(window);
            TutorialSettings.Instance.Background.SetActive(true);

            Canvas canvasComponent = window.Target.AddComponent<Canvas>();
            canvasComponent.overrideSorting = true;
            canvasComponent.sortingOrder = 5;
            window.Target.AddComponent<GraphicRaycaster>();

            Button button = window.Target.GetComponent<Button>();

            button
                .onClick
                .AddListener(() => ClearTutorialStep(window.Target));
        }

        private void ClearTutorialStep(GameObject windowTarget)
        {
            if (windowTarget.TryGetComponent(out GraphicRaycaster raycaster))
                Object.Destroy(raycaster);
 
            if (windowTarget.TryGetComponent(out Canvas canvas))
                Object.Destroy(canvas);

            windowTarget
                .GetComponent<Button>()
                .onClick
                .RemoveListener(() => ClearTutorialStep(windowTarget));

            TutorialSettings.Instance.Background.SetActive(false);
        }
    }
}