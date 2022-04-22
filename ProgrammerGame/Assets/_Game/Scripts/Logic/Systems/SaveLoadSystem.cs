using System;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Extensions;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class SaveLoadSystem : BaseInitSystem
    {
        private readonly GlobalEventsService _globalEvents;

        public SaveLoadSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
        }

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

            _globalEvents.LevelChanged += Save;
            _globalEvents.ApplicationPaused += Save;
        }

        private void CreateNewData()
        {
            CreateProjectsData();
            CreateUpgradesData();
        }

        public override void Dispose()
        {
            _globalEvents.LevelChanged -= Save;
            _globalEvents.ApplicationPaused -= Save;

            Save();
        }

        private void Save()
        {
            _gameData.SavableData.SaveDateTime = DateTime.Now.ToBinary();

            string data = JsonUtility.ToJson(_gameData.SavableData);
            UnityEngine.Debug.Log(data);

            PlayerPrefs.SetString("Save", data);
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            string rawData = PlayerPrefs.GetString("Save");
            SavableData data = JsonUtility.FromJson<SavableData>(rawData);

            data.Init();

            _gameData.SavableData = data;
        }

        private void CreateProjectsData()
        {
            foreach (ProjectSettings settings in _settings.ProjectsSettings)
            {
                ProjectData data = new ProjectData();

                data.projectSettings = settings;

                data.Name = settings.Name;
                data.CurrentTimeToFinish = TimeSpan.FromSeconds(settings.GetTime(0));

                if (settings.OpenLevel > 0)
                    data.State = ProjectState.NotAvailable;
                else
                    data.State = ProjectState.NotPurchased;

                _gameData.SavableData.Projects.Add(data);
            }
        }

        private void CreateUpgradesData()
        {
            _gameData.SavableData.Upgrades.Add(new UpgradeData { Type = UpgradeType.Interior });
            _gameData.SavableData.Upgrades.Add(new UpgradeData { Type = UpgradeType.PC });
            _gameData.SavableData.Upgrades.Add(new UpgradeData { Type = UpgradeType.House });
            _gameData.SavableData.Upgrades.Add(new UpgradeData { Type = UpgradeType.Soft });
        }
    }
}