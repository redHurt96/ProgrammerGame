using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;

namespace _Game.UI.UpgradesTab
{
    public class InteriorUpgradePanel : BaseUpgradePanel
    {
        protected override string EffectTitle => $"+{(int)(Settings.Instance.IncreaseSpeedEffectStrength * 100)}% speed";
        protected override string TotalEffectTitle => $"+{GameDataPresenter.Instance.IncreaseSpeedTotalEffect * 100}% speed";

        protected override bool CheckAdditionalBuyAvailability()
        {
            int interiorLevel = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.Interior).Level;
            int roomLevel = GameDataPresenter.Instance.GetUpgradeData(UpgradeType.House).Level;
            int furnitureToPurchase = Settings.Instance.Rooms.Take(roomLevel + 1).Sum(x => x.FurnitureForPurchase.Length);

            return interiorLevel < furnitureToPurchase;
        }
    }
}