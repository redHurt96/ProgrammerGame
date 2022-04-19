using System;
using _Game.Data;
using _Game.Logic.Systems;
using UnityEngine;

namespace _Game.Common
{
    public static class GlobalEvents
    {
        public static event Action<double> ChangeMoneyIntent;
        public static event Action<double> MoneyCountChanged;
        public static event Action<string> OnTapForMoney;
        public static event Action<ProjectData> RunProjectIntent;
        public static event Action<ProjectData> ProjectStarted;
        public static event Action<string> BuyProgrammerIntent;
        public static event Action<UpgradeType, double> BuyUpgradeIntent;
        public static event Action<UpgradeType> OnUpgraded;
        public static event Action ResetForBoostIntent;
        public static event Action BuyCountChanged;
        public static event Action LevelChanged;
        public static event Action ProgrammedPurchased;
        public static event Action<Vector3> ApartmentObjectSpawned;
        public static event Action DailyBonusUpdated;

        public static void ChangeMoneyCount(double amount, IChangeMoneySystem changeMoneyCountSystem) => MoneyCountChanged?.Invoke(amount);
        public static void AccelerateCoding(string value) => OnTapForMoney?.Invoke(value);
        public static void IntentToRunProject(ProjectData projectData) => RunProjectIntent?.Invoke(projectData);
        public static void RunProject(ProjectData projectData) => ProjectStarted?.Invoke(projectData);

        public static void IntentToChangeMoney(double amount) => ChangeMoneyIntent?.Invoke(amount);
        public static void IntentToBuyProgrammer(string automatedProjectName) =>  BuyProgrammerIntent?.Invoke(automatedProjectName);
        public static void IntentToBuyUpgrade(UpgradeType upgradeType, double price) => BuyUpgradeIntent?.Invoke(upgradeType, price);

        public static void InvokeAfterUpgradeEvent(UpgradeType type) => OnUpgraded?.Invoke(type);
        public static void ResetForBoost() => ResetForBoostIntent?.Invoke();
        public static void InvokeChangeBuyCountsEvent() => BuyCountChanged?.Invoke();
        public static void InvokeChangeLevelEvent() => LevelChanged?.Invoke();
        public static void InvokeOnBuyProgrammerEvent() => ProgrammedPurchased?.Invoke();
        public static void PerformOnFurnitureSpawned(Vector3 position) => ApartmentObjectSpawned?.Invoke(position);
        public static void InvokeOnDailyBonusUpdate() => DailyBonusUpdated?.Invoke();

        public static void Clear()
        {
            MoneyCountChanged = null;
        }
    }
}