using System;
using System.Collections.Generic;
using RH.Utilities.Saving;

namespace _Game.Data
{
    [Serializable]
    public class SavableData : ISavableData
    {
        public double MoneyCount = 0;
        public List<ProjectData> Projects = new List<ProjectData>();
        public List<ProgrammerUpgradeData> AutoRunnedProjects = new List<ProgrammerUpgradeData>();
        public List<UpgradeData> Upgrades = new List<UpgradeData>();
        public long SaveDateTime;
        
        public string Key => "Save";
    }
}