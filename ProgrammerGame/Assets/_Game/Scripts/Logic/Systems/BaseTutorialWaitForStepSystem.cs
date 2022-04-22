using System.Collections;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.GameServices;
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

        protected readonly GameData _gameData;
        protected readonly Settings _settings;

        private readonly TutorialEvents _tutorialEvents;
        private readonly GameDataPresenter _gameDataPresenter;
        private readonly SettingsPresenter _settingsPresenter;
        private readonly Apartment _apartment;
        private readonly GlobalEventsService _globalEvents;

        protected BaseTutorialWaitForStepSystem()
        {
            _gameData = Services.Instance.Single<GameData>();
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
            _settings = Services.Instance.Single<Settings>();
            _settingsPresenter = Services.Instance.Single<SettingsPresenter>();
            _tutorialEvents = Services.Instance.Single<TutorialEvents>();
            _apartment = Services.Instance.Single<Apartment>();
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
        }

        public sealed override void Init()
        {
            if (!_gameData.PersistentData.TutorialData.Steps.Contains(Step))
                _coroutine = CoroutineLauncher.Start(WaitForPerform());
        }

        public sealed override void Dispose()
        {
            if (_coroutine != null)
                CoroutineLauncher.StopIfExist(_coroutine);
        }

        private IEnumerator WaitForPerform()
        {
            yield return new WaitUntil(() => _waitCondition);
            yield return new WaitForSeconds(_delay);

            _tutorialEvents.InvokeEvent(Step);
        }
    }
}