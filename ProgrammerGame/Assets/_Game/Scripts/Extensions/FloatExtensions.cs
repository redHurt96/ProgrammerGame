using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Scripts.Exception
{
    public static class FloatExtensions
    {
        private static Dictionary<int, string> _suffixPerValue = new Dictionary<int, string>
        {
            [3] = "k",
            [6] = "m",
            [9] = "b",
            [12] = "q",
            [12] = "aa",
            [15] = "ab",
            [18] = "ac",
            [21] = "ad",
            [24] = "ae",
            [27] = "af",
            [30] = "ag",
            [33] = "ah",
            [36] = "ai",
            [39] = "aj",
            [42] = "ak",
            [45] = "al",
            [48] = "am",
            [51] = "an",
        };

        public static string ToPriceString(this double value)
        {
            int valueLenght = (int) Mathf.Log10((float) value);

            KeyValuePair<int, string> targetPair = _suffixPerValue
                .LastOrDefault(x => x.Key <= valueLenght);

            string shortValue = string.IsNullOrEmpty(targetPair.Value) 
                ? value.ToString("F0") 
                : (value / Mathf.Pow(10, targetPair.Key)).ToString("F2");

            return $"{shortValue}{targetPair.Value}";
        }
    }
}