using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using _Game.Services;
using _Game.UI.ProjectsTab;
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
        [SerializeField] private Text _needUpgradeTip;

        private void OnEnable()
        {
            UpdateTip();
            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void Start()
        {
            SetupCommonData();

            if (GameData.Instance.SavableData.AutoRunnedProjects.Contains(_programmer.AutomatedProject.Name))
                SetupForPurchasedProgrammer();
            else
                SetupForAvailableProgrammer();

            GlobalEvents.Instance.OnUpgraded += UpdateTip;
        }

        private void OnDestroy() => 
            GlobalEvents.Instance.OnUpgraded -= UpdateTip;

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
            UpdateTip();
        }

        private bool CheckProgrammerAvailability() =>
            Apartment.Instance.ContainSpotFor(_programmer.name)
            && GameData.Instance.SavableData.Projects
                .First(x => x.projectSettings == _programmer.AutomatedProject)
                .State == ProjectState.Active;

        private void BuyProgrammer()
        {
            GlobalEvents.Instance.IntentToBuyProgrammer(_programmer.AutomatedProject.Name);

            SetupForPurchasedProgrammer();

            GlobalEvents.Instance.IntentToChangeMoney(-_programmer.Price);
        }

        private void UpdateTip(UpgradeType type)
        {
            if (type == UpgradeType.House)
                UpdateTip();
        }

        private void UpdateTip() => 
            _needUpgradeTip.gameObject.SetActive(!Apartment.Instance.ContainSpotFor(_programmer.name));
    }
}