﻿using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Ads
{
    public class CoffeeBreakButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private GameData _data;
        private AdsService _ads;

        private void Start()
        {
            _data = Services.Get<GameData>();
            _ads = Services.Get<AdsService>();
        }

        private void Update() => 
            _button.interactable = _data.Ads.CanShowCoffeeBreak && _ads.IsRewardedReady;
    }
}