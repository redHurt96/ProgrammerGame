using System;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class AdsSettings
    {
        public string AppId;

        [Space]
        public float FirstInterstitialDelay;
        public float InterstitialCooldown;

        [Space]
        public float CoffeeBreakLenght;
        public float CoffeeBreakBoost = 1.3f;

        [Space]
        public float ResetBoost = 2f;

        [Space]
        public float LevelRewardBoost = 2f;
    }
}