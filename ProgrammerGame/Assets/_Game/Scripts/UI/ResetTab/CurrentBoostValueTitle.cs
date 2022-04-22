﻿using _Game.Common;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Text))]
    public class CurrentBoostValueTitle : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void OnEnable() => 
            UpdateTitle();

        private void UpdateTitle()
        {
            if (_gameDataPresenter == null)
                return;

            _text.text = "x " + _gameData.PersistentData.MainBoost.ToString("F2");
        }
    }
}