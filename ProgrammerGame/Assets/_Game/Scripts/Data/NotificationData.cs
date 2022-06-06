using System.Collections.Generic;
using RH.Utilities.Saving;

namespace _Game.Data
{
    public class NotificationData : ISavableData
    {
        public string Key => "Notifications";
        public List<int> Ids = new List<int>();
    }
}