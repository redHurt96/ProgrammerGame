using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class DailyBonusSaveLoadSystem : BaseInitSystem
    {
        public override void Init() => 
            GameData.Instance.DailyBonusData.LoadIfSaveExist();

        public override void Dispose() => 
            GameData.Instance.DailyBonusData.Save();
    }
}