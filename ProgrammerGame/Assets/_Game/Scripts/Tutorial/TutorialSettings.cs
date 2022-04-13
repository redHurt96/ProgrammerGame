using System;
using _Game.UI.Tutorial;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Configs
{
    public class TutorialSettings : MonoBehaviourSingleton<TutorialSettings>
    {
        public Setting[] Settings;

        [Space]
        public float WindowNonInteractableTime = 1f;
        public float WindowLifeTime = 5f;

        [Serializable]
        public class Setting
        {
            public TutorialStep Name;
            public TutorialWindow Window;
        }
    }
    
    public enum TutorialStep
    {
        FirstStart_0,
        TapMoney_1,
        CanBuyMoreProjects_2,
    }
}