using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class DailyBonusSaveLoadSystem : BaseInitSystem
    {
        public DailyBonusSaveLoadSystem()
        {
        }

        public override void Init() => 
            _gameData.DailyBonusData.LoadIfSaveExist();

        public override void Dispose() => 
            _gameData.DailyBonusData.Save();
    }
}