using AP.ProgrammerGame.Logic;

namespace AP.ProgrammerGame.UI
{
    public class DeveloperPriceVisibilityChanger : BasePricebuttonVisibilityChanger
    {
        protected override bool IsInteractable => 
            GameData.Instance.MoneyCount >= GameData.Instance.DeveloperPrice &&
            RoomsSpawner.Instance.AvailableRoomsCount > GameData.Instance.PurchasedDevelopersCount;
    }
}