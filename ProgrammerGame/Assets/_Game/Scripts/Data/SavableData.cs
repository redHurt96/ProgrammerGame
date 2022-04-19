using System;
using System.Collections.Generic;

namespace _Game.Data
{
    [Serializable]
    public class SavableData
    {
        public long MoneyCount = 0;
        public List<ProjectData> Projects = new List<ProjectData>();
        public List<string> AutoRunnedProjects = new List<string>();
        public List<UpgradeData> Upgrades = new List<UpgradeData>();
        public long SaveDateTime;
    }
}