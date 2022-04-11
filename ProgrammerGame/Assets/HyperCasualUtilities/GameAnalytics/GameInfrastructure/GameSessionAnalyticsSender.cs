using System;
using UnityEngine;
using GameAnalyticsSDK;
using _Game.Common;
using _Game.Data;
using _Game.Extensions;
using AP.ProgrammerGame;

namespace AP.Utilities.Analytics
{
    public class GameSessionAnalyticsSender : MonoBehaviour
    {
        private void Awake() => 
            GameAnalytics.Initialize();

        private void Start()
        {
            SendStats("Start session");

            GlobalEvents.LevelChanged += SendOnNewLevel;
            GlobalEvents.OnUpgraded += SendOnBuyUpgrade;
            GlobalEvents.ProgrammedPurchased += SendOnProgrammedPurchased;
            GlobalEvents.ResetForBoostIntent += SendOnReset;
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                SendStats("App pause");
        }

        private void OnDestroy()
        {
            GlobalEvents.LevelChanged -= SendOnNewLevel;
            GlobalEvents.OnUpgraded -= SendOnBuyUpgrade;
            GlobalEvents.ProgrammedPurchased -= SendOnProgrammedPurchased;
            GlobalEvents.ResetForBoostIntent -= SendOnReset;
        }

        private void SendOnReset() => SendStats("Reset for boost");
        private void SendOnProgrammedPurchased() => SendStats("Programmer purchased");
        private void SendOnBuyUpgrade(UpgradeType arg1) => SendStats("Buy upgrade");
        private void SendOnNewLevel() => SendStats("New level");

        private void SendStats(string eventName) => 
            GameAnalytics.NewDesignEvent(eventName, GameData.Instance.ToDictionary());
    }
}