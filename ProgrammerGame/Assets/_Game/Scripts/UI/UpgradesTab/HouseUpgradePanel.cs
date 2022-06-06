using _Game.Configs;
using _Game.Data;
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
            _tip.enabled = !GameData.Instance.CanBuyNewRoom();

        protected override bool CheckAdditionalBuyAvailability() => 
            GameData.Instance.CanBuyNewRoom();

        private int GetNewProgrammersCount()
        {
            int roomLevel = GameData.Instance.RoomLevel();

            if (roomLevel + 1 == Settings.Instance.Rooms.Length)
                return 0;

            return Settings.Instance.Rooms[roomLevel + 1].ProgrammerSpots.Length;
        }
    }
}