using System.Collections.Generic;
using System.Linq;
using _Game.Configs;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Data
{
    public class GameData : Singleton<GameData>, IService
    {
        //saved
        public SavableData SavableData = new SavableData();
        public DailyBonusData DailyBonusData = new DailyBonusData();
        public PersistentData PersistentData = new PersistentData();

        //not saved
        public readonly List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public int BuyCount = 1;
        public GameState GameState;
        public AdsData Ads = new AdsData();
    }
}