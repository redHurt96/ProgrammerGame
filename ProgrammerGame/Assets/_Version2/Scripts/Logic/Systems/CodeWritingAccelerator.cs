using System;
using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class CodeWritingAccelerator : IDisposable
    {
        private GameData _gameData => GameData.Instance;

        public CodeWritingAccelerator()
        {
            GlobalEvents.OnCodingAccelerationIntent += Accelerate;
        }

        public void Dispose() => 
            GlobalEvents.OnCodingAccelerationIntent -= Accelerate;

        private void Accelerate()
        {
            _gameData.CodeWritingProgress = 
                Mathf.Min(_gameData.CodeWritingProgress + _gameData.AccelerationCodeProgressPercent, 1f);
            GlobalEvents.WriteCode();
        }
    }
}