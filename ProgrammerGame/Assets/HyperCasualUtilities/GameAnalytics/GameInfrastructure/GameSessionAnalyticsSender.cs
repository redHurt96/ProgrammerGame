using UnityEngine;
using GameAnalyticsSDK;
using _Game.Common;
using _Game.Data;
using _Game.Extensions;

namespace AP.Utilities.Analytics
{
    public class GameSessionAnalyticsSender : MonoBehaviour
    {
        private void Awake() => 
            GameAnalytics.Initialize();

        private void Start()
        {
            SendStats(GAProgressionStatus.Start, "Start session");

            EventsMediator.Instance.LevelChanged += SendOnNewLevel;
            EventsMediator.Instance.OnUpgraded += SendOnBuyUpgrade;
            EventsMediator.Instance.ProgrammedPurchased += SendOnProgrammedPurchased;
            EventsMediator.Instance.ResetForBoostIntent += SendOnReset;
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                SendStats(GAProgressionStatus.Complete,"App pause");
        }

        private void OnApplicationQuit() => 
            SendStats(GAProgressionStatus.Complete,"App close");

        private void OnDestroy()
        {
            EventsMediator.Instance.LevelChanged -= SendOnNewLevel;
            EventsMediator.Instance.OnUpgraded -= SendOnBuyUpgrade;
            EventsMediator.Instance.ProgrammedPurchased -= SendOnProgrammedPurchased;
            EventsMediator.Instance.ResetForBoostIntent -= SendOnReset;
        }

        private void SendOnReset(float f) => SendStats("Reset for boost");
        private void SendOnProgrammedPurchased() => SendStats("Programmer purchased");
        private void SendOnBuyUpgrade(UpgradeType arg1) => SendStats("Buy upgrade");
        private void SendOnNewLevel() => SendStats("New level");

        private void SendStats(GAProgressionStatus status, string eventName)
        {
            GameAnalytics.NewProgressionEvent(status, eventName, GameData.Instance.ToDictionary());
            Debug.Log($"Send progression event {status} - {eventName}");
        }

        private void SendStats(string eventName)
        {
            GameAnalytics.NewDesignEvent(eventName, GameData.Instance.ToDictionary());
            Debug.Log($"Send design event {eventName}");
        }
    }
}