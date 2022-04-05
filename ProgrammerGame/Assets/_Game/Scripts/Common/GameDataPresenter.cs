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

        public int IncreaseSpeedTotalEffect => 
            (int) (_gameData.Upgrades.First(x => x.Type == UpgradeType.Interior).Level *
                                                        (Settings.Instance.IncreaseSpeedEffectStrength));

        public int IncreaseMoneyTotalEffect =>
            (int) (_gameData.Upgrades.First(x => x.Type == UpgradeType.PC).Level *
                   (Settings.Instance.IncreaseMoneyEffectStrength));

        public int NewProgrammersCount => 999;
        public int TotalProgrammersCount => 1000;

        public UpgradeData GetUpgradeData(UpgradeType type) => 
            _gameData.Upgrades.First(x => x.Type == type);
    }
}