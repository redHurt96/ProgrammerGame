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

        protected readonly GameData _data;
        protected readonly Settings _settings;

        private readonly WindowsManager _windowsManager;
        private readonly TutorialEvents _tutorialEvents;

        private Coroutine _coroutine;

        private WaitForSeconds _updateConditionRandomTime => new WaitForSeconds(Random.Range(.01f, .2f));

        protected BaseTutorialWaitForStepSystem()
        {
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();

            _windowsManager = Services.Get<WindowsManager>();
            _tutorialEvents = Services.Get<TutorialEvents>();
        }

        public sealed override void Init()
        {
            if (!_data.PersistentData.TutorialData.Steps.Contains(Step))
                _coroutine = CoroutineLauncher.Start(WaitForPerform());
        }

        public sealed override void Dispose()
        {
            if (_coroutine != null)
                CoroutineLauncher.Stop(_coroutine);
        }

        private IEnumerator WaitForPerform()
        {
            while (!_waitCondition || _windowsManager.IsAnyWindowShown)
                yield return _updateConditionRandomTime;

            yield return new WaitForSeconds(_delay);

            _tutorialEvents.InvokeEvent(Step);
        }
    }
}