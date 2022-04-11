using System;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class SaveLoadSystem : BaseInitSystem
    {
        public override void Init()
        {
            if (PlayerPrefs.HasKey("Need reset") || !PlayerPrefs.HasKey("Save"))
            {
                PlayerPrefs.DeleteKey("Need reset");
                PlayerPrefs.DeleteKey("Save");
                PlayerPrefs.Save();

                CreateNewData();
            }
            else
            {
                LoadData();
            }
        }

        private void CreateNewData()
        {
            CreateProjectsData();
            CreateUpgradesData();
        }

        public override void Dispose() => 
            Save();

        private void Save()
        {
            GameData.Instance.SavableData.SaveDateTime = DateTime.Now.ToBinary();

            string data = JsonUtility.ToJson(GameData.Instance.SavableData);
            UnityEngine.Debug.Log(data);

            PlayerPrefs.SetString("Save", data);
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            string rawData = PlayerPrefs.GetString("Save");
            SavableData data = JsonUtility.FromJson<SavableData>(rawData);

            GameData.Instance.SavableData = data;
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

                GameData.Instance.SavableData.Projects.Add(data);
            }
        }

        private void CreateUpgradesData()
        {
            var interior = new UpgradeData { Type = UpgradeType.Interior };
            var pc = new UpgradeData { Type = UpgradeType.PC };
            var house = new UpgradeData { Type = UpgradeType.House };

            GameData.Instance.SavableData.Upgrades.Add(interior);
            GameData.Instance.SavableData.Upgrades.Add(pc);
            GameData.Instance.SavableData.Upgrades.Add(house);
        }
    }
}