using System.Linq;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Settings = _Game.Configs.Settings;

namespace _Game.Common
{
    public class GameDataPresenter : IService
    {
        private readonly GameData _gameData;
        private readonly Settings _settings;

        public GameDataPresenter()
        {
            _gameData = Services.Instance.Single<GameData>();
            _settings = Services.Instance.Single<Settings>();
        }

        public float IncreaseSpeedTotalEffect => 
            _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Interior).Level *
            _settings.IncreaseSpeedEffectStrength;

        public float IncreaseMoneyTotalEffect =>
            _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.PC).Level *
            _settings.IncreaseMoneyEffectStrength;
        
        public float MoneyForTap
        {
            get
            {
                int level = _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Soft).Level;
                return Mathf.Max(1, _settings.MoneyForTap.GetPrice(level) * _gameData.PersistentData.MainBoost);
            }
        }

        public float MoneyForTapForNewLevel
        {
            get
            {
                int level = _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Soft).Level;
                return (_settings.MoneyForTap.GetPrice(level + 1) - _settings.MoneyForTap.GetPrice(level)) 
                       * _gameData.PersistentData.MainBoost;
            }
        }

        public long IncomePerSec =>
            (long) _gameData.SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => Mathf.Max((float) x.Income / x.Time, 1f));

        public UpgradeData GetUpgradeData(UpgradeType type) => 
            _gameData.SavableData.Upgrades.First(x => x.Type == type);

        public int RoomLevel => 
            GetUpgradeData(UpgradeType.House).Level;

        public float BoostForProgress =>
            1 +
            _gameData.SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => x.Level / 500f) / 9f * _settings.BoostForResetBaseValue;

        public double GetRewardForLevel() => 
            IncomePerSec * _settings.TimeForLevelReward;

        public int CalculateLevel() => 
            (int) Mathf.Log10((float) _gameData.PersistentData.TotalEarnedMoney);

        public bool CanBuyNewRoom()
        {
            int interiorLevel = GetUpgradeData(UpgradeType.Interior).Level;
            int roomLevel = GetUpgradeData(UpgradeType.House).Level;
            int furnitureToPurchase = _settings.Rooms.Take(roomLevel + 1).Sum(x => x.FurnitureForPurchase.Length);

            return interiorLevel == furnitureToPurchase 
                   && roomLevel < _settings.Rooms.Length - 1;
        }
    }
}