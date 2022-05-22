using System;
using System.Collections.Generic;

namespace _Game.Data
{
    [Serializable]
    public class SavableData
    {
        public double MoneyCount = 0;
        public List<ProjectData> Projects = new List<ProjectData>();
        public List<ProgrammerUpgradeData> AutoRunnedProjects = new List<ProgrammerUpgradeData>();
        public List<UpgradeData> Upgrades = new List<UpgradeData>();
        public long SaveDateTime;
        public bool IsProgrammersTabUnlocked;
        public bool IsUpgradesTabUnlocked;
    }
}