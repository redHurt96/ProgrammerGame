using RH.Utilities.Coroutines;
using System;
using System.Collections;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class CodeWritingProcess : IDisposable
    {
        private GameData _gameData => GameData.Instance;

        public CodeWritingProcess()
        {
            CoroutineLauncher.Start(ExecuteProcess());
        }

        public void Dispose() => 
            CoroutineLauncher.Stop(ExecuteProcess());

        private IEnumerator ExecuteProcess()
        {
            while (Application.isPlaying)
            {
                WriteCode();
                CompleteWriteCodeIfPossible();

                yield return null;
            }
        }

        private void WriteCode()
        {
            _gameData.CodeWritingProgress += Time.deltaTime / _gameData.CodeWritingTime;
            GlobalEvents.WriteCode();
        }

        private void CompleteWriteCodeIfPossible()
        {
            if (_gameData.CodeWritingProgress >= 1)
            {
                _gameData.CodeWritingProgress = 0;
                GlobalEvents.CompleteWriteCode();
            }
        }
    }
}