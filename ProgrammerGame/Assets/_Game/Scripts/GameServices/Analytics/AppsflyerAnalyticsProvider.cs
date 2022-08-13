﻿using System.Collections.Generic;
using System.Linq;
using _Game.GameServices.Analytics;
using AppsFlyerSDK;

namespace _Game.GameServices
{
    public class AppsflyerAnalyticsProvider : IAnalyticsProvider, IAdsAnalyticsProvider
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

        public void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result, bool connection) =>
            AppsFlyer.sendEvent($"show ad", new Dictionary<string, string>
            {
                [nameof(AdsEventType)] = eventType.ToString(),
                [nameof(AdType)] = adType.ToString(),
                [nameof(placement)] = placement,
                [nameof(result)] = result,
            });
    }
}