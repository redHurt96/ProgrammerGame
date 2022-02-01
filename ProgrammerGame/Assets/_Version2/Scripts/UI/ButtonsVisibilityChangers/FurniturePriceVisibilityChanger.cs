namespace AP.ProgrammerGame.UI
{
    public class FurniturePriceVisibilityChanger : BasePricebuttonVisibilityChanger
    {
        protected override bool IsInteractable => GameData.Instance.MoneyCount >= GameData.Instance.FurniturePrice &&
            FurnitureRefs.Instance.FurnitureToPurchase.Length - 1 > GameData.Instance.PurchasedFurnitureCount;
    }
}