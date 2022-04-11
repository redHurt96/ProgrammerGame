using System;
using _Game.Common;
using _Game.Data;
using _Game.Logic.MonoBehaviours;
using _Game.Logic.Systems;
using UnityEngine;

namespace AP.ProgrammerGame
{
    public static class GlobalEvents
    {
        public static event Action CodeWrittenComplete;
        public static event Action CodeWritten;
        public static event Action<long> ChangeMoneyIntent;
        public static event Action<long> MoneyCountChanged;
        public static event Action OnCodingAccelerated;
        public static event Action<Money> MoneyCreated;
        public static event Action<ProjectData> RunProjectIntent;
        public static event Action<ProjectData> ProjectStarted;
        public static event Action<string> BuyProgrammerIntent;
        public static event Action<UpgradeType, long> BuyUpgradeIntent;
        public static event Action<UpgradeType> OnUpgraded;
        public static event Action ResetForBoostIntent;
        public static event Action BuyCountChanged;

        public static void CompleteWriteCode() => CodeWrittenComplete?.Invoke();
        public static void WriteCode() => CodeWritten?.Invoke();

        public static void ChangeMoneyCount(long amount, ChangeMoneyCountSystem changeMoneyCountSystem) => MoneyCountChanged?.Invoke(amount);
        public static void AccelerateCoding() => OnCodingAccelerated?.Invoke();
        public static void IntentToRunProject(ProjectData projectData) => RunProjectIntent?.Invoke(projectData);
        public static void RunProject(ProjectData projectData) => ProjectStarted?.Invoke(projectData);

        public static void IntentToChangeMoney(long amount) => ChangeMoneyIntent?.Invoke(amount);
        public static void IntentToBuyProgrammer(string automatedProjectName) =>  BuyProgrammerIntent?.Invoke(automatedProjectName);
        public static void IntentToBuyUpgrade(UpgradeType upgradeType, long price) => BuyUpgradeIntent?.Invoke(upgradeType, price);

        public static void InvokeAfterUpgradeEvent(UpgradeType type) => OnUpgraded?.Invoke(type);
        public static void ResetForBoost() => ResetForBoostIntent?.Invoke();
        public static void InvokeChangeBuyCountsEvent() => BuyCountChanged?.Invoke();
    }
}