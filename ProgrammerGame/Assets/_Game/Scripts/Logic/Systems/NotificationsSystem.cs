using System;
using System.Text;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Saving;
using RH.Utilities.ServiceLocator;
using Unity.Notifications.Android;

namespace _Game.Logic.Systems
{
    public class NotificationsSystem : IInitSystem
    {
        private readonly EventsMediator _eventsMediator;
        private readonly NotificationData _data;
        private readonly NotificationsSettings _settings;
        private readonly long _idleIncomeSeconds;

        private AndroidNotificationChannel _channel;

        public NotificationsSystem()
        {
            _eventsMediator = Services.Get<EventsMediator>();
            _data = Services.Get<GameData>().Notifications;
            _settings = Services.Get<Settings>().Notifications;
            _idleIncomeSeconds = Services.Get<Settings>().IdleIncomeSeconds;
        }

        public void Init()
        {
            RegisterChannel();
            ClearScheduledNotifications();
            ScheduleRetentionNotifications();

            PrintIds();
        }

        private void RegisterChannel()
        {
            _channel = new AndroidNotificationChannel
            {
                Id = NotificationsSettings.DEFAULT_CHANNEL_ID,
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications",
            };

            AndroidNotificationCenter.RegisterNotificationChannel(_channel);
        }

        private void ClearScheduledNotifications()
        {
            PrintIds();

            foreach (int id in _data.Ids) 
                AndroidNotificationCenter.CancelNotification(id);

            AndroidNotificationCenter.CancelAllNotifications();
            _data.Ids.Clear();
        }

        private void PrintIds()
        {
            var builder = new StringBuilder();
            builder.AppendLine("NOTES IDS");

            foreach (int id in _data.Ids)
                builder.AppendLine(id.ToString());

            UnityEngine.Debug.Log(builder.ToString());
        }

        private void ScheduleRetentionNotifications()
        {
            for (int i = 0; i < _settings.RetentionDaysToSend; i++)
            {
                for (int j = 0; j < _settings.NotesPerSingleDay; j++)
                {
                    AndroidNotification notification = GetRetentionNotification(i, j);

                    int id = AndroidNotificationCenter.SendNotification(notification, _channel.Id);

                    _data.Ids.Add(id);
                }
            }
        }

        private AndroidNotification GetRetentionNotification(int i, int j)
        {
            string dayCaption = i == 0 ? "day" : "days";
            string text = $"You have not returned to the game for {i + 1} {dayCaption}";
            int hours = _settings.AllowableTimeStart +
                        _settings.AllowableTimeInterval * (j + 1) / _settings.NotesPerSingleDay;
            DateTime fireTime = DateTime.Today.AddDays(i + 1).AddHours(hours);
            
            var notification = CreateNotification(text, fireTime);
            return notification;
        }

        private static AndroidNotification CreateNotification(string text, DateTime fireTime)
        {
            var notification = new AndroidNotification
            {
                Title = "Programmer Idle",
                Text = text,
                FireTime = fireTime,
                SmallIcon = NotificationsSettings.SMALL_ICON_NAME,
                LargeIcon = NotificationsSettings.LARGE_ICON_NAME,
            };
            return notification;
        }
    }
}