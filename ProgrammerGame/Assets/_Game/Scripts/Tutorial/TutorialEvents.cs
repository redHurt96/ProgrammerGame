using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.GameServices;
using _Game.UI.Tutorial;
using RH.Utilities.ServiceLocator;
using UnityEngine.Events;

namespace _Game.Tutorial
{
    public class TutorialEvents : IService
    {
        private readonly Dictionary<TutorialStep, UnityAction> _actions = new Dictionary<TutorialStep, UnityAction>();

        private readonly WindowsChangeService _windowsService;
        private readonly GlobalEventsService _globalEvents;
        private readonly GameData _gameData;

        public TutorialEvents()
        {
            _windowsService = Services.Instance.Single<WindowsChangeService>();
            _gameData = Services.Instance.Single<GameData>();
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
        }

        public void CreateActionFrom(TutorialWindow window) => 
            _actions.Add(window.Step, () => _windowsService.Show(window));

        public void InvokeEvent(TutorialStep name)
        {
            if (_actions.ContainsKey(name))
            {
                _actions[name]();

                _gameData.PersistentData.TutorialData.Steps.Add(name);

                _globalEvents.InvokeOnTutorialStepReceiveEvent();
            }
        }
    }
}