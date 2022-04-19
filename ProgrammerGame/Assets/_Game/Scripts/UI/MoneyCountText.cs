using System;
using _Game.Common;
using _Game.Data;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI
{
    public class MoneyCountText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void Start() => 
            GlobalEvents.Instance.MoneyCountChanged += UpdateText;

        private void OnDestroy() => 
            GlobalEvents.Instance.MoneyCountChanged -= UpdateText;

        private void UpdateText(double l) =>
            _text.text = GameData.Instance.SavableData.MoneyCount.ToPriceString();
    }
}