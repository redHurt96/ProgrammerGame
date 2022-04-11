using System.Collections.Generic;

namespace _Game.Data
{
    public class SavableData
    {
        public long MoneyCount = 0;
        public List<ProjectData> Projects = new List<ProjectData>();
        public List<string> AutoRunnedProjects = new List<string>();
        public List<UpgradeData> Upgrades = new List<UpgradeData>();
        public long SaveDateTime;

        public int Level;
        public long TotalEarnedMoney;
    }
}