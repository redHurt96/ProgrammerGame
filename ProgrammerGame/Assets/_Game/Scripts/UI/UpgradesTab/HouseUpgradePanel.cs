using _Game.Common;
using _Game.Configs;
using _Game.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public class HouseUpgradePanel : BaseUpgradePanel
    {
        [SerializeField] private Text _tip;

        protected override string EffectTitle => $"+{GetNewProgrammersCount()} programmers";
        protected override string TotalEffectTitle => $"{_apartment.ProgrammersSpotCount} programmers";

        private void Update() => 
            _tip.enabled = !_gameDataPresenter.CanBuyNewRoom();

        protected override bool CheckAdditionalBuyAvailability() => 
            _gameDataPresenter.CanBuyNewRoom();

        private int GetNewProgrammersCount()
        {
            int roomLevel = _gameDataPresenter.RoomLevel;

            if (roomLevel + 1 == _settings.Rooms.Length)
                return 0;

            return _settings.Rooms[roomLevel + 1].ProgrammerSpots.Length;
        }
    }
}