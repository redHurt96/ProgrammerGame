using System.Collections.Generic;
using _Game.GameServices.Analytics;
using Facebook.Unity;

namespace _Game.GameServices
{
    public class FBAnalyticsProvider : IAnalyticsProvider, IAdsAnalyticsProvider
    {
        public void Initialize() => 
            FB.Init();

        public void Send(string eventName, Dictionary<string, object> data) => 
            FB.LogAppEvent(eventName, parameters: data);

        public void SendSessionStart(string eventName, Dictionary<string, object> data) => 
            FB.LogAppEvent(eventName, parameters: data);

        public void SendSessionComplete(string eventName, Dictionary<string, object> data) => 
            FB.LogAppEvent(eventName, parameters: data);

        public void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result, bool connection) =>
            FB.LogAppEvent("Ads event", parameters: new Dictionary<string, object>
            {
                [nameof(AdsEventType)] = eventType.ToString(),
                [nameof(AdType)] = adType.ToString(),
                [nameof(placement)] = placement,
                [nameof(result)] = result,
            });
    }
}