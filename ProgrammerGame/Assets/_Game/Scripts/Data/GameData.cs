using System.Collections.Generic;
using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;

namespace _Game.Data
{
    public class GameData : IService
    {
        //saved
        public SavableData SavableData = new SavableData();
        public DailyBonusData DailyBonusData = new DailyBonusData();
        public readonly PersistentData PersistentData = new PersistentData();

        //not saved
        public readonly List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public int BuyCount = 1;
        public GameState GameState;
        public Stack<BaseWindow> WindowsStack = new Stack<BaseWindow>();
    }

    public enum GameState
    {
        Init,
        Play
    }
}