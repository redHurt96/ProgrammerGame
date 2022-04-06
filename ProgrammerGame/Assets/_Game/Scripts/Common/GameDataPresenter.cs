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
    }
}