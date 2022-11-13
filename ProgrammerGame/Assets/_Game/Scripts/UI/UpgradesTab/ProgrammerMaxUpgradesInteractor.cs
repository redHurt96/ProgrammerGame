using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.Extensions;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.UpgradesTab
{
    public class ProgrammerMaxUpgradesInteractor : MonoBehaviour
    {
        [SerializeField] private ProgrammerSettings _programmerSettings;

        [Space] 
        [SerializeField] private GameObject[] _toEnable;
        [SerializeField] private GameObject[] _toDisable;
        
        private GameData _data;
        private ProgrammerUpgradeData _upgradeData;
        private Settings _settings;
        private EventsMediator _events;

        private string _projectName => _programmerSettings.AutomatedProject.Name;
        
        private void Start()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
            _events = Services.Get<EventsMediator>();

            CheckCurrentProgrammer();

            _events.ProgrammedPurchased += CheckCurrentProgrammer;
        }

        private void CheckCurrentProgrammer()
        {
            if (_data.HasProgrammerData(_projectName))
            {
                _events.ProgrammedPurchased -= CheckCurrentProgrammer;

                _upgradeData = _data.GetProgrammerUpgradeData(_projectName);
                _upgradeData.Upgraded += UpdateTipVisibility;

                UpdateTipVisibility();
            }
        }

        private void OnDestroy()
        {
            if (_data == null || _events == null)
                return;
            
            if (_data.HasProgrammerData(_projectName))
                _upgradeData.Upgraded -= UpdateTipVisibility;
            else
                _events.ProgrammedPurchased -= CheckCurrentProgrammer;
        }

        private void UpdateTipVisibility(string s = "")
        {
            bool isMaxLevelReached = _upgradeData.Level >= _settings.AllProgrammersSettings.Upgrades.Length;
            
            _toEnable.ForEach(x => x.SetActive(isMaxLevelReached));
            _toDisable.ForEach(x => x.SetActive(!isMaxLevelReached));
        }
    }
}