using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class PriceSettings
    {
        public float _offset;
        public float _linear = 1;
        public float _exponential = 1;
        public float _additional = 1;

        public long GetPrice(int level) =>
            (long) (_offset + _linear * Mathf.Pow(level, _exponential) * Mathf.Max(1f, level / 25 * _additional));
    }
}