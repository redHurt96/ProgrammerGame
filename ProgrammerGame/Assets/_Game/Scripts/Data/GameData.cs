using System.Collections.Generic;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;

namespace _Game.Data
{
    public class GameData : Singleton<GameData>, IService
    {
        //saved
        public SavableData SavableData = new SavableData();
        public DailyBonusData DailyBonusData = new DailyBonusData();
        public PersistentData PersistentData = new PersistentData();
        public NotificationData Notifications = new NotificationData();

        //not saved
        public readonly List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public int BuyCount = 1;
        public GameState GameState;
        public AdsData Ads = new AdsData();
    }
}