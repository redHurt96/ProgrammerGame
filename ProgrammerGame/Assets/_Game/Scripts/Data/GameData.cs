using System.Collections.Generic;
using RH.Utilities.SingletonAccess;

namespace _Game.Data
{
    public class GameData : Singleton<GameData>
    {
        public SavableData SavableData = new SavableData();

        //saved separately
        public float MainBoost;
        public TutorialData TutorialData = new TutorialData();

        public readonly List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public float CodeWritingProgress = 0f;
        public int BuyCount = 1;
    }
}