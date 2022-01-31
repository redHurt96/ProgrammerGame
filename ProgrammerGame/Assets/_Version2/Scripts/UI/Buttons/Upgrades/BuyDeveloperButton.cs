using AP.ProgrammerGame_v2.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame_v2.UI
{
    public class BuyDeveloperButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            RemoveMoney();
            BuyFurniture();
            ChangeGameData();

            GlobalEvents.UpdateMoneyCount();
        }

        private static void RemoveMoney() =>
            Wallet.Instance.ChangeMoneyCount(-GameData.Instance.DeveloperPrice);

        private static void BuyFurniture() =>
            OfficeUpgradeManager.Instance.BuyFurniture();

        private static void ChangeGameData()
        {
            GameData.Instance.PurchasedDevelopersCount++;
            GameData.Instance.Level += Settings.Instance.LevelPerDeveloper;
        }
    }
}