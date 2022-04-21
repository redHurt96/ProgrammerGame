using System.Collections;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public abstract class BaseTutorialWaitForStepSystem : BaseInitSystem
    {
        protected abstract TutorialStep Step { get; }
        protected abstract bool _waitCondition { get; }
        protected abstract float _delay { get; }

        private Coroutine _coroutine;

        public sealed override void Init()
        {
            if (!GameData.Instance.PersistentData.TutorialData.Steps.Contains(Step))
                _coroutine = CoroutineLauncher.Start(WaitForPerform());
        }

        public sealed override void Dispose()
        {
            if (_coroutine != null)
                CoroutineLauncher.StopIfExist(_coroutine);
        }

        private IEnumerator WaitForPerform()
        {
            UnityEngine.Debug.LogWarning($"Wait {Step} tutorial step");
            
            yield return new WaitUntil(() => _waitCondition);
            yield return new WaitForSeconds(_delay);

            UnityEngine.Debug.LogWarning($"Perform {Step} tutorial step");

            TutorialEvents.Instance.InvokeEvent(Step);
        }
    }
}