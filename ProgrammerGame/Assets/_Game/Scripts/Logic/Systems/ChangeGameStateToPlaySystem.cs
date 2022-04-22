using _Game.Data;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class ChangeGameStateToPlaySystem : IInitSystem
    {
        public void Init() => 
            GameData.Instance.GameState = GameState.Play;
    }
}