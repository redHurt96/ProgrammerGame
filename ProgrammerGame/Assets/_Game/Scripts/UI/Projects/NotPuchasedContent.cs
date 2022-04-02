using System;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI.Projects
{
    public class NotPuchasedContent : MonoBehaviour
    {
        [SerializeField] private Text _name;
        [SerializeField] private Text _price;
        [SerializeField] private Button _button;

        public void Setup(ProjectData projectData, Action onBuyClick)
        {
            _name.text = projectData.Name;
            _price.text = projectData.Price.ToPriceString();

            _button.onClick.AddListener(onBuyClick.Invoke);
        }
    }
}