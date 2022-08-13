using System.Collections.Generic;

namespace _Game.GameServices.Analytics
{
    public interface IAnalyticsProvider
    {
        void Initialize();
        void Send(string eventName, Dictionary<string, object> data);
        void SendSessionStart(string eventName, Dictionary<string, object> data);
        void SendSessionComplete(string eventName, Dictionary<string, object> data);
    }
}