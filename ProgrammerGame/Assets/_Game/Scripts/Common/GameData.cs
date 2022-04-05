using System.Collections.Generic;
using _Game.Data;
using RH.Utilities.SingletonAccess;

namespace AP.ProgrammerGame
{
    public class GameData : Singleton<GameData>
    {
        public long MoneyCount = 0;

        public List<ProjectData> Projects = new List<ProjectData>();
        public List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public List<string> AutoRunnedProjects = new List<string>();
        public List<UpgradeData> Upgrades = new List<UpgradeData>();

        //not for save
        public float CodeWritingProgress = 0f;


    }
}