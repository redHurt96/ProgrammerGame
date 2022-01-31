namespace AP.ProgrammerGame_v2.UI
{
    public class DeveloperPriceVisibilityChanger : BasePricebuttonVisibilityChanger
    {
        protected override bool IsInteractable => GameData.Instance.MoneyCount >= GameData.Instance.DeveloperPrice;
    }
}