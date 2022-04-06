using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class TimeSettings
    {
        public long _startTime;
        public long _endDecreasingLevel;
        public long _endTime;

        private float _linear => -(_startTime - _endTime) / (float)_endDecreasingLevel;

        public long GetTime(int level) => 
            level < _endDecreasingLevel ? (long) (_startTime + _linear * level) : _endTime;
    }
}