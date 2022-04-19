using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Data;

namespace _Game.Extensions
{
    public static class GameDataExtensions
    {
        public static Dictionary<string, object> ToDictionary(this GameData gameData)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                ["Main boost"] = gameData.PersistentData.MainBoost,
                ["Money count"] = gameData.SavableData.MoneyCount,
                ["Auto run projects"] = gameData.SavableData.AutoRunnedProjects,
                ["Level"] = gameData.PersistentData.Level,
                ["Total earned money"] = gameData.PersistentData.TotalEarnedMoney,
            };

            foreach (ProjectData project in gameData.SavableData.Projects)
                dictionary.Add(project.Name, project.Level);

            foreach (UpgradeData upgradeData in gameData.SavableData.Upgrades)
                dictionary.Add(upgradeData.Type.ToString(), upgradeData.Level);

            return dictionary;
        }
    }
}