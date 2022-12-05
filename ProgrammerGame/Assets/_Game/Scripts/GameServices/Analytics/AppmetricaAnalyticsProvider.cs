using System.Collections.Generic;
using System.Linq;
using _Game.Data;
using UnityEngine;

namespace _Game.GameServices.Analytics
{
    public class AppmetricaAnalyticsProvider : IAnalyticsProvider, IAdsAnalyticsProvider
    {
        private IYandexAppMetrica _appMetrica => AppMetrica.Instance;
        
        public void Initialize() => 
            _appMetrica.ActivateWithConfiguration(new YandexAppMetricaConfig("2f319314-7329-4eb6-8ebc-09e17dc9bd41"));

        public void Send(string eventName, Dictionary<string, object> data) => 
            _appMetrica.ReportEvent(eventName, data);

        public void SendSessionStart(string eventName, Dictionary<string, object> data)
        {
            _appMetrica.ReportEvent(eventName, CreateProgressionData());
            _appMetrica.SendEventsBuffer();
        }

        public void SendSessionComplete(string eventName, Dictionary<string, object> data)
        {
            _appMetrica.ReportEvent(eventName, CreateExitData());
            _appMetrica.SendEventsBuffer();
        }

        public void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result, bool connection)
        {
            Dictionary<string,object> data = CreateFullAdsData(eventType, adType, placement, result, connection);
            _appMetrica.ReportEvent(eventType.ToString(), data);
        }

        private static Dictionary<string, object> CreateFullAdsData(AdsEventType eventType, AdType adType, string placement, string result,
            bool connection)
        {
            Dictionary<string, object> data = CreateAdsData(adType, placement, result, connection);

            if (eventType == AdsEventType.video_ads_watch)
            {
                foreach (KeyValuePair<string,object> pair in CreateProgressionData())
                    data.Add(pair.Key, pair.Value);
            }
            
            return data;
        }

        private static Dictionary<string, object> CreateAdsData(AdType adType, string placement, string result, bool connection) =>
            new()
            {
                ["ad_type"] = adType.ToString(),
                ["placement"] = placement,
                ["result"] = result,
                ["connection"] = connection.ToString(),
            };

        private static Dictionary<string, object> CreateProgressionData() =>
            new()
            {
                ["level_count"] = GameData.Instance.PersistentData.SessionsCount,
                ["level_loop"] = GameData.Instance.PersistentData.ResetCount,
            };

        private static Dictionary<string, object> CreateExitData()
        {
            Dictionary<string, object> data = CreateProgressionData();
            
            data.Add("result", "leave");
            data.Add("time", Time.realtimeSinceStartup);

            return data;
        }
    }
}