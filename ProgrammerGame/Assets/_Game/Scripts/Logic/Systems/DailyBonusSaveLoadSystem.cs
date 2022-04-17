using _Game.Data;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class DailyBonusSaveLoadSystem : BaseInitSystem
    {
        public override void Init()
        {
            if (GameData.Instance.DailyBonusData.HasSave())
                GameData.Instance.DailyBonusData.Load();
        }

        public override void Dispose() => 
            GameData.Instance.DailyBonusData.Save();
    }
}