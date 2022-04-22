using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ChangeGameStateToPlaySystem : IInitSystem
    {
        private readonly GameData _gameData;

        public ChangeGameStateToPlaySystem()
        {
            _gameData = Services.Instance.Single<GameData>();
        }

        public void Init() => 
            _gameData.GameState = GameState.Play;
    }
}