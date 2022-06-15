using System;
using System.Globalization;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using Unity.Notifications.Android;

namespace _Game.Logic.Systems
{
    public class TestNotificationSystem : IInitSystem
    {
        private AndroidNotificationChannel _channel;
        private NotificationData _data;

        public void Init()
        {
            _data = Services.Get<GameData>().Notifications;

            RegisterChannel();
            ScheduleTestNotification(1);
            ScheduleTestNotification(2);
            ScheduleTestNotification(3);
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

        private void ScheduleTestNotification(int minutes)
        {
            var notification = new AndroidNotification
            {
                Title = "Programmer Idle (TEST)",
                Text = "Test notification " + DateTime.Now.ToString(CultureInfo.CurrentCulture),
                FireTime = DateTime.Now.AddMinutes(minutes),
                SmallIcon = NotificationsSettings.SMALL_ICON_NAME,
                LargeIcon = NotificationsSettings.LARGE_ICON_NAME,
            };

            int id = AndroidNotificationCenter.SendNotification(notification, _channel.Id);

            _data.Ids.Add(id);
        }
    }
}