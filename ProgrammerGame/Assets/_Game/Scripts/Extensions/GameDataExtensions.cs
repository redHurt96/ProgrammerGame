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
                ["main_boost"] = gameData.PersistentData.MainBoost,
                ["moneys_count"] = gameData.SavableData.MoneyCount,
                ["level"] = gameData.PersistentData.Level,
                ["total_earned_money"] = gameData.PersistentData.TotalEarnedMoney,
            };

            foreach (ProjectData project in gameData.SavableData.Projects)
                dictionary.Add(project.Name.Replace(' ', '_'), project.Level);

            foreach (UpgradeData upgrade in gameData.SavableData.Upgrades)
                dictionary.Add(upgrade.Type.ToString().Replace(' ', '_'), upgrade.Level);

            return dictionary;
        }
    }
}