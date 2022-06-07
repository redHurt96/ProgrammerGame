using System.Collections;
using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    public class ProjectAdsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private AdsService _ads;
        private GameData _data;
        private ProjectData _project;
        private GlobalEvents _events;

        private void Start()
        {
            _events ??= Services.Get<GlobalEvents>();
            _events.MoneyCountChanged += UpdateButtonVisibility;
        }

        private void Update() => CheckAdsAvailability();

        private void UpdateButtonVisibility() => UpdateButtonVisibility(0);

        private void UpdateButtonVisibility(double amount)
        {
            if (_project == null)
            {
                _button.gameObject.SetActive(false);
                return;
            }

            _data ??= Services.Get<GameData>();
            _ads ??= Services.Get<AdsService>();

            if (_data.SavableData.MoneyCount < _project.GetPrice(1) && _ads.IsRewardedReady)
                Invoke(nameof(EnableButton), 1f);
        }

        private void EnableButton()
        {
            if (_data.SavableData.MoneyCount < _project.GetPrice(1) && _ads.IsRewardedReady)
                _button.gameObject.SetActive(true);
        }

        public void Setup(ProjectData project)
        {
            _project = project;

            UpdateButtonVisibility();

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(ShowAd);
        }

        private void ShowAd() => 
            _ads.ShowRewarded("Project", AddLevel);

        private void AddLevel() => _project.Buy(1);

        private void CheckAdsAvailability()
        {
            if (!_ads.IsRewardedReady)
                _button.gameObject.SetActive(false);
        }
    }
}