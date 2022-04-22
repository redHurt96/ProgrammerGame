using System;
using _Game.Common;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI
{
    public class LevelTitle : MonoBehaviour
    {
        [SerializeField] private Text _title;

        private void Start()
        {
            UpdateTitle();

            _globalEvents.LevelChanged += UpdateTitle;
        }

        private void OnDestroy() => 
            _globalEvents.LevelChanged -= UpdateTitle;

        private void UpdateTitle() => 
            _title.text = _gameData.PersistentData.Level.ToString();
    }
}