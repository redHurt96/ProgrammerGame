using System.Collections.Generic;
using System.Linq;
using _Game.Common;
using _Game.Data;

namespace _Game.Extensions
{
    public static class GameDataExtensions
    {
        public static Dictionary<string, object> ToDictionary(this GameData gameData) =>
            new Dictionary<string, object>
            {
                ["Main boost"] = gameData.MainBoost,
                ["Money count"] = gameData.SavableData.MoneyCount,
                ["Projects"] = gameData.SavableData.Projects.ToDictionary(
                    x => x.Name,
                    y => y.ToDictionary()),
                ["Auto run projects"] = gameData.SavableData.AutoRunnedProjects,
                ["Upgrades"] = gameData.SavableData.Upgrades.ToDictionary(
                    x => x.Type.ToString(),
                    y => y.ToDictionary()),
                ["Level"] = gameData.SavableData.Level,
                ["Total earned money"] = gameData.SavableData.TotalEarnedMoney,
            };

        private static Dictionary<string, object> ToDictionary(this ProjectData projectData) =>
            new Dictionary<string, object>
            {
                ["Name"] = projectData.Name,
                ["State"] = projectData.State.ToString(),
                ["Level"] = projectData.Level,
            };

        private static Dictionary<string, object> ToDictionary(this UpgradeData upgradeData) =>
            new Dictionary<string, object>
            {
                ["Type"] = upgradeData.Type,
                ["Level"] = upgradeData.Level,
            };
    }
}