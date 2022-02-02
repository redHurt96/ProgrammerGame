using AP.ProgrammerGame.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame.UI
{
    public class BuyDeveloperButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            RemoveMoney();
            ChangeGameData();

            GlobalEvents.UpdateMoneyCount();
            GlobalEvents.BuyDeveloperComplete();
        }

        private static void RemoveMoney() =>
            Wallet.Instance.ChangeMoneyCount(-GameData.Instance.DeveloperPrice);

        private static void ChangeGameData()
        {
            GameData.Instance.PurchasedDevelopersCount++;
            GameData.Instance.Level += Settings.Instance.LevelPerDeveloper;
        }
    }
}