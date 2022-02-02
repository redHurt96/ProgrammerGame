using AP.ProgrammerGame.Logic;
using RH.Utilities.UI;

namespace AP.ProgrammerGame.UI
{
    public class BuyPcButton : BaseActionButton
    {
        protected override void PerformOnClick()
        {
            RemoveMoney();
            BuyFurniture();
            ChangeGameData();

            GlobalEvents.UpdateMoneyCount();
        }

        private static void RemoveMoney() =>
            Wallet.Instance.ChangeMoneyCount(-GameData.Instance.PcPrice);

        private static void BuyFurniture() =>
            HouseUpgradeManager.Instance.BuyPc();

        private static void ChangeGameData()
        {
            GameData.Instance.Level += Settings.Instance.LevelPerPc;
            GameData.Instance.PurchasedComputersCount++;
        }
    }
}