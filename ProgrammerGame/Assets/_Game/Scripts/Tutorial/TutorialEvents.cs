using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Services;
using _Game.UI.Tutorial;
using RH.Utilities.SingletonAccess;
using UnityEngine.Events;

namespace _Game.Tutorial
{
    public class TutorialEvents : Singleton<TutorialEvents>
    {
        private readonly Dictionary<TutorialStep, UnityAction> _actions = new Dictionary<TutorialStep, UnityAction>();

        public void CreateActionFrom(TutorialWindow window) => 
            _actions.Add(window.Step, () => WindowsManager.Show(window));

        public void InvokeEvent(TutorialStep name)
        {
            if (_actions.ContainsKey(name))
            {
                _actions[name]();

                GameData.Instance.TutorialData.Steps.Add(name);
            }
        }
    }
}