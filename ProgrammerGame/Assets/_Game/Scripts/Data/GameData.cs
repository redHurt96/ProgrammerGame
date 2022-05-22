using System.Collections.Generic;
using System.Linq;
using _Game.Configs;
using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Data
{
    public partial class GameData : Singleton<GameData>, IService
    {
        //saved
        public SavableData SavableData = new SavableData();
        public DailyBonusData DailyBonusData = new DailyBonusData();
        public readonly PersistentData PersistentData = new PersistentData();

        //not saved
        public readonly List<RunProjectProcess> RunnedProjects = new List<RunProjectProcess>();
        public int BuyCount = 1;
        public GameState GameState;
        public Stack<BaseWindow> WindowsStack = new Stack<BaseWindow>();

        
    }

    public partial class GameData
    {
        public ProjectData GetProject(string projectName) => 
            SavableData.Projects.Find(x => x.Name == projectName);

        public bool IsProjectAutoRunned(string projectName) =>
            SavableData.AutoRunnedProjects.Any(x => x.ProjectName == projectName);

        public ProgrammerUpgradeData GetProgrammerData(string projectName) =>
            SavableData.AutoRunnedProjects.First(x => x.ProjectName == projectName);

        public float IncreaseSpeedTotalEffect => 
            GetUpgradeData(UpgradeType.Interior).Level * Settings.Instance.IncreaseSpeedEffectStrength;

        public float IncreaseMoneyTotalEffect =>
            GetUpgradeData(UpgradeType.PC).Level * Settings.Instance.IncreaseMoneyEffectStrength;

        public float MoneyForTap => 
            Mathf.Max(1, Settings.Instance.MoneyForTap.GetPrice(GetUpgradeData(UpgradeType.Soft).Level) * PersistentData.MainBoost);

        public float MoneyForTapForNewLevel
        {
            get
            {
                int level = GetUpgradeData(UpgradeType.Soft).Level;
                return (Settings.Instance.MoneyForTap.GetPrice(level + 1) - Settings.Instance.MoneyForTap.GetPrice(level)) * PersistentData.MainBoost;
            }
        }

        public long IncomePerSec =>
            (long) SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => Mathf.Max((float) x.Income / x.Time, 1f));

        public UpgradeData GetUpgradeData(UpgradeType type) => 
            SavableData.Upgrades.First(x => x.Type == type);

        public int RoomLevel => 
            GetUpgradeData(UpgradeType.House).Level;

        public float BoostForProgress =>
            1 +
            SavableData.Projects
                .Where(x => x.State == ProjectState.Active)
                .Sum(x => x.Level / 500f) / 9f * Settings.Instance.BoostForResetBaseValue;

        public double GetRewardForLevel() => Mathf.Max(Settings.Instance.MinLevelReward,
            IncomePerSec * Settings.Instance.TimeForLevelReward);

        public int CalculateLevel() => 
            (int) Mathf.Log10((float) PersistentData.TotalEarnedMoney);

        public double MoneyNeededForLevel(int level) => Mathf.Pow(10, level);

        public float ReachNewLevelProgress =>
            (float) (PersistentData.TotalEarnedMoney / MoneyNeededForLevel(PersistentData.Level + 1));

        public bool CanBuyNewRoom()
        {
            int interiorLevel = GetUpgradeData(UpgradeType.Interior).Level;
            int roomLevel = GetUpgradeData(UpgradeType.House).Level;
            int furnitureToPurchase = Settings.Instance.Rooms.Take(roomLevel + 1).Sum(x => x.FurnitureForPurchase.Length);

            return interiorLevel == furnitureToPurchase 
                   && roomLevel < Settings.Instance.Rooms.Length - 1;
        }
    }
}