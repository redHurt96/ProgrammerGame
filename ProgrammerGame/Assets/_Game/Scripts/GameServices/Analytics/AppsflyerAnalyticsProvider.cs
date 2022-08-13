using System.Collections.Generic;
using System.Linq;
using _Game.GameServices.Analytics;
using AppsFlyerSDK;

namespace _Game.GameServices
{
    public class AppsflyerAnalyticsProvider : IAnalyticsProvider
    {
        public void Initialize()
        {
            AppsFlyer.initSDK("r9vNC83N8nYpCzYGigyjUh", null);
            AppsFlyer.startSDK();
        }

        public void Send(string eventName, Dictionary<string, object> data) => 
            AppsFlyer.sendEvent(eventName, ConvertData(data));

        public void SendSessionStart(string eventName, Dictionary<string, object> data) => 
            Send(eventName, data);

        public void SendSessionComplete(string eventName, Dictionary<string, object> data) => 
            Send(eventName, data);

        private Dictionary<string, string> ConvertData(Dictionary<string, object> data) =>
            data.ToDictionary(x => x.Key, y => y.Value.ToString());
    }
}