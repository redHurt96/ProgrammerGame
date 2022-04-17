using _Game.Data;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Saving;

namespace _Game.Logic.Systems
{
    public class TutorialsSaveSystem : BaseInitSystem
    {
        public override void Init() => 
            GameData.Instance.TutorialData.LoadIfSaveExist();

        public override void Dispose() => 
            GameData.Instance.TutorialData.Save();
    }
}