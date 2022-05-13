﻿using _Game.Common;
using _Game.Configs;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Button))]
    public class ResetButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Update() =>
            _button.interactable = 
                GameData.Instance.BoostForProgress 
                * GameData.Instance.PersistentData.MainBoost 
                - GameData.Instance.PersistentData.MainBoost 
                > Settings.Instance.OpenResetThreshold;
    }
}