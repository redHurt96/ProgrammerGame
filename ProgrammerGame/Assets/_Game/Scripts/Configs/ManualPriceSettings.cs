using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class ManualPriceSettings
    {
        [SerializeField] private long[] _prices;
        
        public long GetPrice(int level)
        {
            if (_prices.Length < level)
                return 0;

            return _prices[level];
        }
    }
}