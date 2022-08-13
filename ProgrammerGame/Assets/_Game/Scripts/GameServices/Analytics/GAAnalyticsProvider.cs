using System.Collections.Generic;
using _Game.GameServices.Analytics;
using GameAnalyticsSDK;

namespace _Game.GameServices
{
    public class GAAnalyticsProvider : IAnalyticsProvider
    {
        public void Initialize() => 
            GameAnalytics.Initialize();

        public void Send(string eventName, Dictionary<string, object> data) => 
            GameAnalytics.NewDesignEvent(eventName, data);

        public void SendSessionStart(string eventName, Dictionary<string, object> data) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, eventName, data);

        public void SendSessionComplete(string eventName, Dictionary<string, object> data) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, eventName, data);
    }
}