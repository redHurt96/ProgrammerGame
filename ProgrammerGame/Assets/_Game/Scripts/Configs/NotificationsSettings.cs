using System;

namespace _Game.Configs
{
    [Serializable]
    public class NotificationsSettings
    {
        public const string DEFAULT_CHANNEL_ID = "default_channel";
        public const string SMALL_ICON_NAME = "small_icon";
        public const string LARGE_ICON_NAME = "large_icon";

        public int RetentionDaysToSend = 14;
        public int NotesPerSingleDay = 2;
        public int AllowableTimeStart = 10;
        public int AllowableTimeEnd = 22;

        public int AllowableTimeInterval => AllowableTimeEnd - AllowableTimeStart;
    }
}