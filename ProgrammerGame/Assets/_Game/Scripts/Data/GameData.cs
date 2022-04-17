using System.Collections.Generic;
using _Game.Services;
using _Game.UI.Windows;
using RH.Utilities.SingletonAccess;

namespace _Game.Data
{
    public class GameData : Singleton<GameData>
    {
        //saved
        public SavableData SavableData = new SavableData();
        public float MainBoost;
        public TutorialData TutorialData = new TutorialData();
        public DailyBonusData DailyBonusData = new DailyBonusData();

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