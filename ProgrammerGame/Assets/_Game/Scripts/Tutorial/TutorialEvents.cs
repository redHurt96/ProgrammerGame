using System.Collections.Generic;
using _Game.Common;
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
    public class TutorialEvents : Singleton<TutorialEvents>, IService
    {
        private readonly Dictionary<TutorialStep, UnityAction> _actions = new Dictionary<TutorialStep, UnityAction>();

        private readonly WindowsManager _windowsManager;
        private readonly GameData _data;

        public TutorialEvents()
        {
            _windowsManager = Services.Get<WindowsManager>();
            _data = Services.Get<GameData>();
        }

        public void CreateActionFrom(TutorialWindow window) => 
            _actions.Add(window.Step, () => ShowTutorial(window));

        public void InvokeEvent(TutorialStep name)
        {
            if (_actions.ContainsKey(name))
            {
                _actions[name]();

                _data.PersistentData.TutorialData.Steps.Add(name);

                GlobalEvents.Instance.InvokeOnTutorialStepReceiveEvent();
            }
        }

        private void ShowTutorial(TutorialWindow window)
        {
            _windowsManager.Show(window);

            SetupTarget(window);
        }

        private void SetupTarget(TutorialWindow window)
        {
            Canvas canvasComponent = window.Target.AddComponent<Canvas>();
            canvasComponent.overrideSorting = true;
            canvasComponent.sortingOrder = 7;
            window.Target.AddComponent<GraphicRaycaster>();

            Button button = window.Target.GetComponent<Button>();

            button
                .onClick
                .AddListener(() => ClearTutorialStep(window));
        }

        private void ClearTutorialStep(TutorialWindow window)
        {
            if (window.HasShown)
                return;

            if (window.Target.TryGetComponent(out GraphicRaycaster raycaster))
                Object.Destroy(raycaster);
 
            if (window.Target.TryGetComponent(out Canvas canvas))
                Object.Destroy(canvas);

            window
                .Target
                .GetComponent<Button>()
                .onClick
                .RemoveListener(() => ClearTutorialStep(window));

            _windowsManager.Hide(window);
        }
    }
}