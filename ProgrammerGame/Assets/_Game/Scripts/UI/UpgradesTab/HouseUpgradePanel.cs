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

        protected override bool CheckAdditionalBuyAvailability()
        {
            int interiorLevel = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.Interior).Level;
            int roomLevel = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.House).Level;
            int furnitureToPurchase = Settings.Instance.Rooms.Take(roomLevel + 1).Sum(x => x.FurnitureForPurchase.Length);

            return interiorLevel == furnitureToPurchase 
                   && roomLevel < Settings.Instance.Rooms.Length - 1;
        }

        private int GetNewProgrammersCount()
        {
            int roomLevel = GameDataPresenter.Instance.RoomLevel;

            if (roomLevel + 1 == Settings.Instance.Rooms.Length)
                return 0;

            return Settings.Instance.Rooms[roomLevel + 1].ProgrammerSpots.Length;
        }
    }
}