using System.Linq;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Settings = _Game.Configs.Settings;

namespace _Game.Common
{
    public class GameDataPresenter : IService
    {
        private GameData _gameData => GameData.Instance;

        public float IncreaseSpeedTotalEffect => 
            _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Interior).Level *
            Settings.Instance.IncreaseSpeedEffectStrength;

        public float IncreaseMoneyTotalEffect =>
            _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.PC).Level *
            Settings.Instance.IncreaseMoneyEffectStrength;
        
        public float MoneyForTap
        {
            get
            {
                int level = _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Soft).Level;
                return Mathf.Max(1, Settings.Instance.MoneyForTap.GetPrice(level) * GameData.Instance.PersistentData.MainBoost);
            }
        }

        public float MoneyForTapForNewLevel
        {
            get
            {
                int level = _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Soft).Level;
                return (Settings.Instance.MoneyForTap.GetPrice(level + 1) - Settings.Instance.MoneyForTap.GetPrice(level)) * GameData.Instance.PersistentData.MainBoost;
            }
        }
        

        public long IncomePerSec =>
            (long) GameData.Instance.SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => Mathf.Max((float) x.Income / x.Time, 1f));

        public UpgradeData GetUpgradeData(UpgradeType type) => 
            _gameData.SavableData.Upgrades.First(x => x.Type == type);

        public int RoomLevel => 
            GetUpgradeData(UpgradeType.House).Level;

        public float BoostForProgress =>
            1 +
            GameData.Instance.SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => x.Level / 500f) / 9f * Settings.Instance.BoostForResetBaseValue;

        public double GetRewardForLevel() => 
            IncomePerSec * Settings.Instance.TimeForLevelReward;

        public int CalculateLevel() => 
            (int) Mathf.Log10((float) GameData.Instance.PersistentData.TotalEarnedMoney);

        public bool CanBuyNewRoom()
        {
            int interiorLevel = GetUpgradeData(UpgradeType.Interior).Level;
            int roomLevel = GetUpgradeData(UpgradeType.House).Level;
            int furnitureToPurchase = Settings.Instance.Rooms.Take(roomLevel + 1).Sum(x => x.FurnitureForPurchase.Length);

            return interiorLevel == furnitureToPurchase 
                   && roomLevel < Settings.Instance.Rooms.Length - 1;
        }
    }
}