using System;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class TimeSettings
    {
        public float _startTime;

        [SerializeField] private int _timerDecreaseLevelCount = 25;
        [SerializeField] private float _minProjectTime = .25f;

        public float GetTime(int level) => 
            Mathf.Max(_minProjectTime, _startTime / Mathf.Pow(2f, level / _timerDecreaseLevelCount));
    }
}