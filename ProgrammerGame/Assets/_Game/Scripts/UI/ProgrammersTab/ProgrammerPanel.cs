using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.GameServices;
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

        private GameData _gameData;
        private GlobalEventsService _globalEvents;
        private Apartment _apartmentService;

        private void OnEnable()
        {
            UpdateTip();
            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void Start()
        {
            _gameData = Services.Instance.Single<GameData>();
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _apartmentService = Services.Instance.Single<Apartment>();

            SetupCommonData();

            if (_gameData.SavableData.AutoRunnedProjects.Contains(_programmer.AutomatedProject.Name))
                SetupForPurchasedProgrammer();
            else
                SetupForAvailableProgrammer();

            _globalEvents.OnUpgraded += UpdateTip;

            _priceButtonVisibilityComponent.UpdateVisibility();
        }

        private void OnDestroy() => 
            _globalEvents.OnUpgraded -= UpdateTip;

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
            _apartmentService.ContainSpotFor(_programmer.name)
            && _gameData.SavableData.Projects
                .First(x => x.projectSettings == _programmer.AutomatedProject)
                .State == ProjectState.Active;

        private void BuyProgrammer()
        {
            _globalEvents.IntentToBuyProgrammer(_programmer.AutomatedProject.Name);

            SetupForPurchasedProgrammer();

            _globalEvents.IntentToChangeMoney(-_programmer.Price);
        }

        private void UpdateTip(UpgradeType type)
        {
            if (type == UpgradeType.House)
                UpdateTip();
        }

        private void UpdateTip() => 
            _needUpgradeTip.gameObject.SetActive(!_apartmentService.ContainSpotFor(_programmer.name));
    }
}