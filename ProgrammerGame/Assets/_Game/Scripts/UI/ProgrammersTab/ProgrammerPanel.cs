using System;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using _Game.Services;
using _Game.UI.ProjectsTab;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProgrammersTab
{
    public class ProgrammerPanel : MonoBehaviour
    {
        [SerializeField] private ProgrammerSettings _programmer;

        [Space]
        [SerializeField] private Text _name;
        [SerializeField] private Text _description;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        [SerializeField] private Text _price;
        [SerializeField] private PriceButtonVisibilityComponent _priceButtonVisibilityComponent;

        private void OnEnable() => 
            _priceButtonVisibilityComponent.UpdateVisibility();

        private void Start()
        {
            SetupCommonData();

            if (GameData.Instance.SavableData.AutoRunnedProjects.Contains(_programmer.AutomatedProject.Name))
                SetupForPurchasedProgrammer();
            else
                SetupForAvailableProgrammer();
        }

        private void SetupCommonData()
        {
            _name.text = _programmer.Name;
            _description.text = $"{_programmer.AutomatedProject.Name} auto run";
            _icon.sprite = _programmer.Icon;
        }

        private void SetupForPurchasedProgrammer() => 
            _button.gameObject.SetActive(false);

        private void SetupForAvailableProgrammer()
        {
            _price.text = _programmer.Price.ToPriceString();
            _button.onClick.AddListener(BuyProgrammer);
            _priceButtonVisibilityComponent.SetPriceFunc(() => _programmer.Price);
            _priceButtonVisibilityComponent.SetAdditionalCondition(CheckProgrammerAvailability);
        }

        private bool CheckProgrammerAvailability() => 
            Apartment.Instance.ContainSpotFor(_programmer.name);

        private void BuyProgrammer()
        {
            GlobalEvents.IntentToBuyProgrammer(_programmer.AutomatedProject.Name);

            SetupForPurchasedProgrammer();

            GlobalEvents.IntentToChangeMoney(-_programmer.Price);
        }
    }
}