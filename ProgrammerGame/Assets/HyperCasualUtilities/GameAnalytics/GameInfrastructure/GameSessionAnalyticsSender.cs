using System;
using UnityEngine;
using GameAnalyticsSDK;
using _Game.Common;
using _Game.Data;
using _Game.Extensions;
using AP.ProgrammerGame;
using RH.Utilities.ServiceLocator;

namespace AP.Utilities.Analytics
{
    public class GameSessionAnalyticsSender : MonoBehaviour
    {
        private GlobalEventsService _globalEvents;
        private GameData _gameData;

        private void Awake() => 
            GameAnalytics.Initialize();

        private void Start()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameData>();

            SendStats("Start session");

            _globalEvents.LevelChanged += SendOnNewLevel;
            _globalEvents.OnUpgraded += SendOnBuyUpgrade;
            _globalEvents.ProgrammedPurchased += SendOnProgrammedPurchased;
            _globalEvents.ResetForBoostIntent += SendOnReset;
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                SendStats("App pause");
        }

        private void OnDestroy()
        {
            _globalEvents.LevelChanged -= SendOnNewLevel;
            _globalEvents.OnUpgraded -= SendOnBuyUpgrade;
            _globalEvents.ProgrammedPurchased -= SendOnProgrammedPurchased;
            _globalEvents.ResetForBoostIntent -= SendOnReset;
        }

        private void SendOnReset() => SendStats("Reset for boost");
        private void SendOnProgrammedPurchased() => SendStats("Programmer purchased");
        private void SendOnBuyUpgrade(UpgradeType arg1) => SendStats("Buy upgrade");
        private void SendOnNewLevel() => SendStats("New level");

        private void SendStats(string eventName)
        {
            GameAnalytics.NewDesignEvent(eventName, _gameData.ToDictionary());
        }
    }
}