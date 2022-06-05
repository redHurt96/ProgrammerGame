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
    }
}