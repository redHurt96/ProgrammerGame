using System.Linq;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.SingletonAccess;

namespace _Game.Common
{
    public class GameDataPresenter : Singleton<GameDataPresenter>
    {
        private GameData _gameData => GameData.Instance;

        public float IncreaseSpeedTotalEffect => 
            _gameData.Upgrades.First(x => x.Type == UpgradeType.Interior).Level *
            Settings.Instance.IncreaseSpeedEffectStrength;

        public float IncreaseMoneyTotalEffect =>
            _gameData.Upgrades.First(x => x.Type == UpgradeType.PC).Level *
            Settings.Instance.IncreaseMoneyEffectStrength;

        public UpgradeData GetUpgradeData(UpgradeType type) => 
            _gameData.Upgrades.First(x => x.Type == type);

        public int RoomLevel => 
            GetUpgradeData(UpgradeType.House).Level;
    }
}