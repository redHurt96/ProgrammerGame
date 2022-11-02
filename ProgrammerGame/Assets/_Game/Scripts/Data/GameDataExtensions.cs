using System.Collections.Generic;
using System.Linq;
using _Game.Configs;
using _Game.Tutorial;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Data
{
    public static class GameDataExtensions
    {
        private static Settings _settings => Services.Get<Settings>(); 
        
        public static float FullResetBoost(this GameData data) =>
            data.PersistentData.AddendBoost.Value + data.PersistentData.MainBoost;
        
        public static float ResetProgress(this GameData data) =>
            data.PersistentData.AddendBoost.Value / _settings.OpenResetThreshold;
        
        public static bool CanReset(this GameData data) =>
            data.ResetProgress() >= 1f;

        public static bool ContainsTutorialStep(this GameData data, TutorialStep step) =>
            data.PersistentData.TutorialData.Steps.Contains(step);

        public static ProjectData GetProject(this GameData data, string projectName) => 
            data.SavableData.Projects.Find(x => x.Name == projectName);

        public static bool IsProjectAutoRunned(this GameData data, string projectName) =>
            data.SavableData.AutoRunnedProjects.Any(x => x.ProjectName == projectName);

        public static ProgrammerUpgradeData GetProgrammerUpgradeData(this GameData data, string projectName) =>
            data.SavableData.AutoRunnedProjects.First(x => x.ProjectName == projectName);

        public static float SpeedTotalEffect(this GameData data) => 
            GetUpgradeData(data, UpgradeType.Interior).Level * _settings.IncreaseSpeedEffectStrength;

        public static float MoneyTotalEffect(this GameData data) =>
            GetUpgradeData(data, UpgradeType.Interior).Level * _settings.IncreaseMoneyEffectStrength;

        public static float MoneyForTap(this GameData data)
        {
            float baseValue = Mathf.Max(1,
                _settings.MoneyForTap.GetPrice(GetUpgradeData(data, UpgradeType.Soft).Level) *
                data.PersistentData.MainBoost);

            if (_settings.MoneyForTapIncomeCoefficient > 0f)
                baseValue *= data.IncomePerSec() * _settings.MoneyForTapIncomeCoefficient;
            
            return baseValue;
        }

        public static float MoneyForTapForNewLevel(this GameData data)
        {
            int level = GetUpgradeData(data, UpgradeType.Soft).Level;
            return (_settings.MoneyForTap.GetPrice(level + 1) - _settings.MoneyForTap.GetPrice(level)) *
                   data.PersistentData.MainBoost;
        }

        public static long IncomePerSec(this GameData data) =>
            (long) data.SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => Mathf.Max((float) x.Income / x.Time, 1f));

        public static UpgradeData GetUpgradeData(this GameData data, UpgradeType type) => 
            data.SavableData.Upgrades.First(x => x.Type == type);

        public static float BoostForProgress(this GameData data) =>
            data.SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => x.Level / 500f) / 9f * _settings.BoostForResetBaseValue;

        public static double GetRewardForLevel(this GameData data) => Mathf.Max(_settings.MinLevelReward,
            IncomePerSec(data) * _settings.TimeForLevelReward);

        public static int CalculateLevel(this GameData data) => 
            (int) Mathf.Log10((float) data.PersistentData.TotalEarnedMoney * _settings.NewLevelsFrequency);

        public static double MoneyNeededForLevel(this GameData data, int level) => 
            Mathf.Pow(10, level) / _settings.NewLevelsFrequency;

        public static float ReachNewLevelProgress(this GameData data) =>
            (float) (data.PersistentData.TotalEarnedMoney / MoneyNeededForLevel(data, data.PersistentData.Level + 1));

        public static IEnumerable<ProjectData> GetActiveProjects(this GameData gameData) => 
            gameData.SavableData.Projects
                .Where(x => x.State == ProjectState.Active);
    }
}