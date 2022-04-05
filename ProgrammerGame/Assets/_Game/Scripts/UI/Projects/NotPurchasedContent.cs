using System;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Projects
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
            _price.text = projectData.Price.ToPriceString();
            priceButtonVisibilityComponent.SetPriceFunc(() => projectData.Price);

            _button.onClick.AddListener(onBuyClick.Invoke);
        }
    }
}