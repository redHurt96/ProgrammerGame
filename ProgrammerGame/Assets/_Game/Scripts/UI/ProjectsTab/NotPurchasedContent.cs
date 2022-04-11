using System;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using GameAnalyticsSDK.Setup;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    public class NotPurchasedContent : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _price;
        [SerializeField] private Button _button;
        [SerializeField] private PriceButtonVisibilityComponent priceButtonVisibilityComponent;

        public void Setup(ProjectData projectData, ProjectSettings settings, Action onBuyClick)
        {
            _icon.sprite = settings.Icon;
            _name.text = projectData.Name;
            _price.text = projectData.GetPrice(1).ToPriceString();
            priceButtonVisibilityComponent.SetPriceFunc(() => projectData.GetPrice(1));

            _button.onClick.AddListener(onBuyClick.Invoke);
        }
    }
}