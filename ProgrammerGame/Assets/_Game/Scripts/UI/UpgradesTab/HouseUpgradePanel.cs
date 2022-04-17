using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Services;

namespace _Game.UI.UpgradesTab
{
    public class HouseUpgradePanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{GetNewProgrammersCount()} programmers";
        protected override string TotalEffectTitle => $"{Apartment.Instance.ProgrammersSpotCount} programmers";

        protected override bool CheckAdditionalBuyAvailability() => 
            GameDataPresenter.Instance.CanBuyNewRoom();

        private int GetNewProgrammersCount()
        {
            int roomLevel = GameDataPresenter.Instance.RoomLevel;

            if (roomLevel + 1 == Settings.Instance.Rooms.Length)
                return 0;

            return Settings.Instance.Rooms[roomLevel + 1].ProgrammerSpots.Length;
        }
    }
}