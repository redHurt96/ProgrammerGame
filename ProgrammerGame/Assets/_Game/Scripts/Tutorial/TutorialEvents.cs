using System.Collections.Generic;
using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using _Game.UI.Tutorial;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine.Events;

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

                EventsMediator.Instance.InvokeOnTutorialStepReceiveEvent();
            }
        }

        private void ShowTutorial(TutorialWindow window) => 
            _windowsManager.Show(window);
        
#if UNITY_EDITOR || DEVELOPMENT_BUILD

        public void ClearTutorial() => 
            _actions.Clear();
#endif
    }
}