using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CodeWritingAccelerationSystem : BaseInitSystem
    {
        private GameData _gameData => GameData.Instance;

        public override void Init() => 
            GlobalEvents.OnCodingAccelerated += Accelerate;

        public override void Dispose() => 
            GlobalEvents.OnCodingAccelerated -= Accelerate;

        private void Accelerate()
        {
            _gameData.CodeWritingProgress = 
                Mathf.Min(_gameData.CodeWritingProgress + _gameData.AccelerationCodeProgressPercent, 1f);
            GlobalEvents.WriteCode();
        }
    }
}