using System;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class TimeSettings
    {
        public float _startTime;
        public int _timerDecreaseLevelCount = 25;

        public float GetTime(int level) =>
            _startTime / Mathf.Pow(2f, level / _timerDecreaseLevelCount);
    }
}