namespace AP.ProgrammerGame_v2.UI
{
    public class PcPriceVisibilityChanger : BasePricebuttonVisibilityChanger
    {
        protected override bool IsInteractable => GameData.Instance.MoneyCount >= GameData.Instance.PcPrice &&
            FurnitureRefs.Instance.Computers.Length - 1 > GameData.Instance.PurchasedComputersCount;
    }
}