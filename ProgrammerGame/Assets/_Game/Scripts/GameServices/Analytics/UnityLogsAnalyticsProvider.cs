using System.Collections.Generic;
using System.Text;

namespace _Game.GameServices.Analytics
{
    public class UnityLogsAnalyticsProvider : IAnalyticsProvider, IAdsAnalyticsProvider
    {
        public void Initialize() => 
            Log("Analytics initialized");

        public void Send(string eventName, Dictionary<string, object> data) => 
            Log($"Send event {eventName} with data {PrintData(data)}");

        public void SendSessionStart(string eventName, Dictionary<string, object> data) => 
            Log($"Send start event {eventName} with data {PrintData(data)}");

        public void SendSessionComplete(string eventName, Dictionary<string, object> data) => 
            Log($"Send complete event {eventName} with data {PrintData(data)}");

        private string PrintData(Dictionary<string, object> data)
        {
            StringBuilder builder = new StringBuilder();

            foreach (KeyValuePair<string,object> pair in data) 
                builder.AppendLine($"{pair.Key}:{pair.Value}");

            return builder.ToString();
        }

        public void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result, bool connection) => 
            Log($"Sent ads event:{eventType}, type:{adType}, placement:{placement}, result:{result}, connection:{connection}");

        private void Log(string message) => 
            UnityEngine.Debug.Log($"[ANALYTICS] {message}");
    }
}