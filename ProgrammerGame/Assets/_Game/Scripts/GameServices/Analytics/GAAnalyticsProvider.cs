using System.Collections.Generic;
using _Game.GameServices.Analytics;
using GameAnalyticsSDK;

namespace _Game.GameServices
{
    public class GAAnalyticsProvider : IAnalyticsProvider, IAdsAnalyticsProvider
    {
        private static readonly Dictionary<AdsEventType, GAAdAction> _actionsMap =
            new Dictionary<AdsEventType, GAAdAction>
            {
                [AdsEventType.video_ads_started] = GAAdAction.Clicked,
                [AdsEventType.video_ads_watch] = GAAdAction.Show,
            };
        
        private static readonly Dictionary<AdType, GAAdType> _adTypeMap =
            new Dictionary<AdType, GAAdType>
            {
                [AdType.interstitial] = GAAdType.Interstitial,
                [AdType.rewarded] = GAAdType.RewardedVideo,
            };

        public void Initialize() => 
            GameAnalytics.Initialize();

        public void Send(string eventName, Dictionary<string, object> data) => 
            GameAnalytics.NewDesignEvent(eventName, data);

        public void SendSessionStart(string eventName, Dictionary<string, object> data) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, eventName, data);

        public void SendSessionComplete(string eventName, Dictionary<string, object> data) => 
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, eventName, data);

        public void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result, bool connection)
        {
            if (_actionsMap.ContainsKey(eventType))
                GameAnalytics.NewAdEvent(_actionsMap[eventType], _adTypeMap[adType], "iron source", placement);
        }
    }
}