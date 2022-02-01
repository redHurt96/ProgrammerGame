using System;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class CodeWritingAccelerator : IDisposable
    {
        private GameData _gameData => GameData.Instance;

        public CodeWritingAccelerator()
        {
            GlobalEvents.OnCodingAccelerated += Accelerate;
        }

        public void Dispose() => 
            GlobalEvents.OnCodingAccelerated -= Accelerate;

        private void Accelerate()
        {
            _gameData.CodeWritingProgress = 
                Mathf.Min(_gameData.CodeWritingProgress + _gameData.AccelerationCodeProgressPercent, 1f);
            GlobalEvents.WriteCode();
        }
    }
}