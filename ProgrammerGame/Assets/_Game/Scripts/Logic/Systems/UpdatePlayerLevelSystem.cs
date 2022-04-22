using System.Collections;
using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class UpdatePlayerLevelSystem : BaseInitSystem
    {
        private readonly GlobalEventsService _globalEvents;
        private readonly GameDataPresenter _gameDataPresenter;
        private readonly GameData _gameData;

        public UpdatePlayerLevelSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
            _gameData = Services.Instance.Single<GameData>();
        }

        public override void Init() =>
            CoroutineLauncher.Start(DelayedSubscribe());

        public override void Dispose() => 
            _globalEvents.MoneyCountChanged -= UpdateLevel;

        private IEnumerator DelayedSubscribe()
        {
            yield return null;

            _globalEvents.MoneyCountChanged += UpdateLevel;
        }
        
        private void UpdateLevel(double money)
        {
            if (money <= 0)
                return;

            _gameData.PersistentData.TotalEarnedMoney += money;
            int level = _gameDataPresenter.CalculateLevel();

            if (level > _gameData.PersistentData.Level)
            {
                _gameData.PersistentData.Level = level;
                _globalEvents.InvokeChangeLevelEvent();
            }
        }
    }
}