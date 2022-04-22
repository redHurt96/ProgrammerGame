using System.Collections;
using _Game.Common;
using _Game.Data;
using GameAnalyticsSDK.Setup;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class AddCurrentMoneySystem : IInitSystem, IChangeMoneySystem
    {
        private GlobalEventsService _globalEvents;
        private GameData _gameData;

        public void Init()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();

            CoroutineLauncher.Start(AddMoneyDelayed());
        }

        private IEnumerator AddMoneyDelayed()
        {
            yield return null;

            _globalEvents.ChangeMoneyCount(_gameData.SavableData.MoneyCount, this);
        }
    }
}