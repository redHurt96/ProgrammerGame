using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using _Game.Scripts.Exception;
using _Game.UI.ProjectsTab;
using RH.Utilities.ServiceLocator;
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
        [SerializeField] private Text _buttonTitle;

        private Apartment _apartment;
        private GameData _data;
        private GlobalEvents _events;

        private void OnEnable()
        {
            _apartment ??= Services.Get<Apartment>();
            _data ??= Services.Get<GameData>();
            _events ??= Services.Get<GlobalEvents>();

            UpdateTip();
            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void Start()
        {
            SetupCommonData();

            if (GameData.Instance.SavableData.AutoRunnedProjects.Any(x => x.ProjectName == _programmer.AutomatedProject.Name))
                SetupForPurchasedProgrammer();
            else
                SetupForAvailableProgrammer();

            _events.OnUpgraded += UpdateTip;

            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void OnDestroy() => 
            _events.OnUpgraded -= UpdateTip;

        private void SetupCommonData()
        {
            _name.text = _programmer.Name;
            _icon.sprite = _programmer.Icon;
        }

        private void SetupForPurchasedProgrammer()
        {
            ProgrammerUpgradeData upgradeData = _data.GetProgrammerData(_programmer.AutomatedProject.Name);

            _description.text = $"Level {upgradeData.Level}";

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(UpgradeProgrammer);

            _buttonTitle.text = "Upgrade";

            _priceButtonVisibilityComponent.SetPriceFunc(() => _programmer.GetPrice(upgradeData.Level));
            _priceButtonVisibilityComponent.SetAdditionalCondition(CheckProgrammerAvailability);
            _price.text = _programmer.GetPrice(upgradeData.Level).ToPriceString();
        }

        private void SetupForAvailableProgrammer()
        {
            _description.text = $"{_programmer.AutomatedProject.Name} auto run";

            _price.text = _programmer.GetPrice(0).ToPriceString();
            _button.onClick.AddListener(BuyProgrammer);
            _priceButtonVisibilityComponent.SetPriceFunc(() => _programmer.GetPrice(0));
            _priceButtonVisibilityComponent.SetAdditionalCondition(CheckProgrammerAvailability);
            _buttonTitle.text = "Hire";

            UpdateTip();
        }

        private bool CheckProgrammerAvailability() =>
            _apartment.ContainSpotFor(_programmer.name)
            && GameData.Instance.SavableData.Projects
                .First(x => x.projectSettings == _programmer.AutomatedProject)
                .State == ProjectState.Active;

        private void BuyProgrammer()
        {
            _events.IntentToBuyProgrammer(_programmer.AutomatedProject.Name);

            SetupForPurchasedProgrammer();

            _events.IntentToChangeMoney(-_programmer.GetPrice(0));
        }

        private void UpgradeProgrammer()
        {
            _events.IntentToUpgradeProgrammer(_programmer.AutomatedProject.Name);

            SetupForPurchasedProgrammer();

            _events.IntentToChangeMoney(-_programmer.GetPrice(0));
        }

        private void UpdateTip(UpgradeType type)
        {
            if (type == UpgradeType.House)
                UpdateTip();
        }

        private void UpdateTip() => 
            _needUpgradeTip.gameObject.SetActive(!_apartment.ContainSpotFor(_programmer.name));
    }
}