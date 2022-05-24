using System.IO;
using System.Linq;
using _Game.Configs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.GameServices
{
    public class SaveLoadPricesService : IService
    {
        private string _path => Path.Combine(Application.streamingAssetsPath, "Prices.json");

        public void Load()
        {
            var projects = Resources.LoadAll<ProjectSettings>("Projects");
            //var pricesSettings = GetPricesFromProject();
            var pricesFromFile = GetPricesFromFile();

            for (int i = 0; i < projects.Length; i++) 
                projects[i]._priceSettings = pricesFromFile[i];
        }

        public void Save()
        {
            var container = new PricesSettingsContainer
            {
                Prices = GetPricesFromProject(),
            };

            if (!Directory.Exists(Application.streamingAssetsPath))
                Directory.CreateDirectory(Application.streamingAssetsPath);

            File.WriteAllText(_path, JsonUtility.ToJson(container));
        }

        private PriceSettings[] GetPricesFromProject() =>
            Resources.LoadAll<ProjectSettings>("Projects")
                .Select(x => x._priceSettings)
                .ToArray();

        private PriceSettings[] GetPricesFromFile() =>
            JsonUtility
                .FromJson<PricesSettingsContainer>(File.ReadAllText(_path))
                .Prices;
    }
}