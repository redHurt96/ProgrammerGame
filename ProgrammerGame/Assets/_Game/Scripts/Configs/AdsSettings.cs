using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class AdsSettings
    {
        public string SdkKey = "6AQkyPv9b4u7yTtMH9PT40gXg00uJOTsmBOf7hDxa_-FnNZvt_qTLnJAiKeb5-2_T8GsI_dGQKKKrtwZTlCzAR";
        
        [Space]
        public float FirstInterstitialDelay;
        public float InterstitialCooldown;

        [Space]
        public float CoffeeBreakLenght;
        public float CoffeeBreakDelay = 60;
        public float CoffeeBreakBoost = 1.3f;
        public float CoffeeBreakIconShowTime = 7f;
        public float CoffeeBreakIconHideTime = 60f;

        [Space]
        public float ResetBoost = 2f;

        [Space]
        public float LevelRewardBoost = 2f;
    }
}