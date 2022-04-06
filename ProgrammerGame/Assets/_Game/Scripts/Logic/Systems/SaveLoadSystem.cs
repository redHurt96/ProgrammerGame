using System;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class SaveLoadSystem : IInitSystem
    {
        public void Init()
        {
            CreateProjectsData();
            CreateUpgradesData();
        }

        private void CreateProjectsData()
        {
            foreach (ProjectSettings settings in Settings.Instance.ProjectsSettings)
            {
                ProjectData data = new ProjectData();

                data.projectSettings = settings;

                data.Name = settings.Name;
                data.CurrentTimeToFinish = TimeSpan.FromSeconds(settings.GetTime(0));

                if (settings.OpenLevel > 0)
                    data.State = ProjectState.NotAvailable;
                else
                    data.State = ProjectState.NotPurchased;

                GameData.Instance.Projects.Add(data);
            }
        }

        private void CreateUpgradesData()
        {
            var interior = new UpgradeData { Type = UpgradeType.Interior };
            var pc = new UpgradeData { Type = UpgradeType.PC };
            var house = new UpgradeData { Type = UpgradeType.House };

            GameData.Instance.Upgrades.Add(interior);
            GameData.Instance.Upgrades.Add(pc);
            GameData.Instance.Upgrades.Add(house);
        }
    }
}