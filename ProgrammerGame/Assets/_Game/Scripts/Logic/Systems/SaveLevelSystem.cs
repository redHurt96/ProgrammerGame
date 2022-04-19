using _Game.Data;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class SaveLevelSystem : BaseInitSystem
    {
        public override void Init() => 
            GameData.Instance.PersistentData.LoadIfSaveExist();

        public override void Dispose() => 
            GameData.Instance.PersistentData.Save();
    }
}