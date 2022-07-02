using _Game.Data;
using RH.Utilities;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ResetBoostAddendVariableInitializeSystem : IInitSystem
    {
        private readonly GameData _data;

        public ResetBoostAddendVariableInitializeSystem() => 
            _data = Services.Get<GameData>();

        public void Init() => 
            _data.PersistentData.AddendBoost = CachedValue<float>.Create(_data.BoostForProgress);
    }
}