using System.Collections.Generic;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.SingletonAccess;
using UnityEngine.Events;

namespace _Game.Tutorial
{
    public class TutorialEvents : Singleton<TutorialEvents>
    {
        private Dictionary<TutorialStep, UnityAction> Actions = new Dictionary<TutorialStep, UnityAction>();

        public void CreateActionFrom(TutorialSettings.Setting setting) => 
            Actions.Add(setting.Name, setting.Window.Enable);

        public void InvokeEvent(TutorialStep name)
        {
            if (Actions.ContainsKey(name))
            {
                Actions[name]();

                GameData.Instance.TutorialData.Steps.Add(name);
                
                GlobalEvents.InvokeOnTutorialStepEvent(this);
            }
        }
    }
}