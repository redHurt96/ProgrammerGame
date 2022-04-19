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

            GlobalEvents.Instance.LevelChanged += UpdateTitle;
        }

        private void OnDestroy() => 
            GlobalEvents.Instance.LevelChanged -= UpdateTitle;

        private void UpdateTitle() => 
            _title.text = GameData.Instance.PersistentData.Level.ToString();
    }
}