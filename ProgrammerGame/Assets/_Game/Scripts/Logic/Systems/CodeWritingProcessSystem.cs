using System.Collections;
using _Game.Configs;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CodeWritingProcessSystem : BaseInitSystem
    {
        private GameData _gameData => GameData.Instance;

        public override void Init() => 
            CoroutineLauncher.Start(ExecuteProcess());

        public override void Dispose() => 
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
            _gameData.CodeWritingProgress += Time.deltaTime / Settings.Instance.CodeWritingTime;
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