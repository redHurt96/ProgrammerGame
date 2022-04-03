using System;
using _Game.Logic.Data;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI.Projects
{
    public class NotPuchasedContent : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _price;
        [SerializeField] private Button _button;

        public void Setup(ProjectData projectData, ProjectSettings settings, Action onBuyClick)
        {
            _icon.sprite = settings.Icon;
            _name.text = projectData.Name;
            _price.text = projectData.Price.ToPriceString();

            _button.onClick.AddListener(onBuyClick.Invoke);
        }
    }
}