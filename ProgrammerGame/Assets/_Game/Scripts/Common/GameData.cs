using System.Collections.Generic;
using _Game.Data;
using RH.Utilities.SingletonAccess;

namespace AP.ProgrammerGame
{
    public class GameData : Singleton<GameData>
    {
        public SavableData SavableData = new SavableData();

        public List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public float CodeWritingProgress = 0f;
    }
}