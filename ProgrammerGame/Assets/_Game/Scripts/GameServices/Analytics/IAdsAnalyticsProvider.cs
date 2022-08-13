namespace _Game.GameServices.Analytics
{
    public interface IAdsAnalyticsProvider
    {
        void SendAdsEvent(AdsEventType eventType, AdType adType, string placement, string result, bool connection);
    }
}