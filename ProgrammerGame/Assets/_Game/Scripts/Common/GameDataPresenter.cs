using System.Collections.Generic;
using System.Linq;
using _Game.Data;
using AP.ProgrammerGame;
using GameAnalyticsSDK.Setup;
using RH.Utilities.SingletonAccess;
using UnityEngine;
using Settings = _Game.Configs.Settings;

namespace _Game.Common
{
    public class GameDataPresenter : Singleton<GameDataPresenter>
    {
        private GameData _gameData => GameData.Instance;

        public float IncreaseSpeedTotalEffect => 
            _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.Interior).Level *
            Settings.Instance.IncreaseSpeedEffectStrength;

        public float IncreaseMoneyTotalEffect =>
            _gameData.SavableData.Upgrades.First(x => x.Type == UpgradeType.PC).Level *
            Settings.Instance.IncreaseMoneyEffectStrength;

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

        public int CalculateLevel() => 
            (int) (Mathf.Pow(Mathf.Log10(GameData.Instance.SavableData.TotalEarnedMoney), 2) - 3);
    }
}