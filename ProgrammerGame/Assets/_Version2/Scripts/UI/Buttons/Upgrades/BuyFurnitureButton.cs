using AP.ProgrammerGame_v2.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame_v2.UI
{
    public class BuyFurnitureButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            RemoveMoney();
            BuyFurniture();
            ChangeGameData();

            GlobalEvents.UpdateMoneyCount();
        }

        private static void RemoveMoney() => 
            Wallet.Instance.ChangeMoneyCount(-GameData.Instance.FurniturePrice);

        private static void BuyFurniture() => 
            HouseUpgradeManager.Instance.BuyFurniture();

        private static void ChangeGameData()
        {
            GameData.Instance.CodeWritingTime *= Settings.Instance.AccelerationPerFurniture;
            GameData.Instance.PurchasedFurnitureCount++;
            GameData.Instance.Level += Settings.Instance.LevelPerFurniture;
        }
    }
}