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
        private readonly EventsMediator _events;
        private readonly Settings _settings;
        private readonly GameData _data;

        public SaveLoadSystem()
        {
            _events = Services.Get<EventsMediator>();
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
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

            _events.LevelChanged += Save;
            _events.ApplicationPaused += Save;
        }

        private void CreateNewData()
        {
            CreateProjectsData();
            CreateUpgradesData();
        }

        public override void Dispose()
        {
            _events.LevelChanged -= Save;
            _events.ApplicationPaused -= Save;

            Save();
        }

        private void Save()
        {
            _data.SavableData.SaveDateTime = DateTime.Now.ToBinary();

            string data = JsonUtility.ToJson(GameData.Instance.SavableData);
            UnityEngine.Debug.Log(data);

            PlayerPrefs.SetString("Save", data);
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            string rawData = PlayerPrefs.GetString("Save");
            SavableData data = JsonUtility.FromJson<SavableData>(rawData);

            data.Init();

            _data.SavableData = data;
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

                _data.SavableData.Projects.Add(data);
            }
        }

        private void CreateUpgradesData()
        {
            GameData.Instance.SavableData.Upgrades.Add(new UpgradeData { Type = UpgradeType.Interior });
            GameData.Instance.SavableData.Upgrades.Add(new UpgradeData { Type = UpgradeType.Soft });
        }
    }
}