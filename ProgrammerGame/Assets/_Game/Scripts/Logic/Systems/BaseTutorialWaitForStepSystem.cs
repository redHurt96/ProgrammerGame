using System.Collections;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using _Game.Tutorial;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public abstract class BaseTutorialWaitForStepSystem : BaseInitSystem
    {
        protected abstract TutorialStep Step { get; }
        protected abstract bool _waitCondition { get; }
        protected abstract float _delay { get; }

        private Coroutine _coroutine;
        private readonly WindowsManager _windowsManager;

        protected BaseTutorialWaitForStepSystem() => 
            _windowsManager = Services.Get<WindowsManager>();

        public sealed override void Init()
        {
            if (!GameData.Instance.PersistentData.TutorialData.Steps.Contains(Step))
                _coroutine = CoroutineLauncher.Start(WaitForPerform());
        }

        public sealed override void Dispose()
        {
            if (_coroutine != null)
                CoroutineLauncher.Stop(_coroutine);
        }

        private IEnumerator WaitForPerform()
        {
            yield return new WaitUntil(() => _waitCondition && !_windowsManager.IsAnyWindowShown);
            yield return new WaitForSeconds(_delay);

            TutorialEvents.Instance.InvokeEvent(Step);
        }
    }
}