namespace AP.ProgrammerGame_v2.UI
{
    public class FurniturePriceVisibilityChanger : BasePricebuttonVisibilityChanger
    {
        protected override bool IsInteractable => GameData.Instance.MoneyCount >= GameData.Instance.FurniturePrice &&
            FurnitureRefs.Instance.FurnitureToPurchase.Length - 1 > GameData.Instance.PurchasedFurnitureCount;
    }
}