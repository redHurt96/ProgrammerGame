using System.Collections.Generic;
using _Game.Data;
using RH.Utilities.SingletonAccess;

namespace _Game.Common
{
    public class GameData : Singleton<GameData>
    {
        public SavableData SavableData = new SavableData();

        //saved separately
        public float MainBoost;

        public List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public float CodeWritingProgress = 0f;
    }
}