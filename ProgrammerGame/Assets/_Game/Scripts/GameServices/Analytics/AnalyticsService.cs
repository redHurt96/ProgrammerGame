using System.Collections.Generic;
using _Game.Data;
using _Game.Extensions;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.GameServices.Analytics
{
    public class AnalyticsService : IService
    {
        private static readonly List<IAnalyticsProvider> _providers = new List<IAnalyticsProvider> 
        {
            new GAAnalyticsProvider(),
            new AppsflyerAnalyticsProvider(),
            new AppmetricaAnalyticsProvider(),
            new UnityLogsAnalyticsProvider(),
        };

        private static readonly List<IAdsAnalyticsProvider> _adsProviders = new List<IAdsAnalyticsProvider>
        {
            new AppmetricaAnalyticsProvider(),
            new UnityLogsAnalyticsProvider(),
        };

        private readonly GameData _data;

        public AnalyticsService()
        {
            _data = Services.Get<GameData>();
            
            _providers
                .ForEach(x => x.Initialize());
        }

        public void Send(string eventName)
        {
            Dictionary<string, object> data = GetData();
            
            _providers
                .ForEach(x => x.Send(eventName, data));
        }

        public void SendSessionStart(string eventName)
        {
            Dictionary<string, object> data = GetData();
            
            _providers
                .ForEach(x => x.SendSessionStart(eventName, data));
        }

        public void SendSessionComplete(string eventName)
        {
            Dictionary<string, object> data = GetData();
            
            _providers
                .ForEach(x => x.SendSessionComplete(eventName, data));
        }

        public void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result) => 
            _adsProviders
                .ForEach(x => x.SendAdsEvent(eventType, adType, placement, result, Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork));

        private Dictionary<string, object> GetData() =>
            _data.ToDictionary();
    }
}