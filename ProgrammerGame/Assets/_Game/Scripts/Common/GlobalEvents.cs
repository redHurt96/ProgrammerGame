using System;
using _Game.Logic.Data;
using _Game.Logic.Systems;
using AP.ProgrammerGame.Logic;
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
        public static event Action<GameObject> MoneyCreated;
        public static event Action<FurnitureSlotType, GameObject> FurnitureCreated;
        public static event Action BuyDeveloperCompleted;
        public static event Action<ProjectData> RunProjectIntent;
        public static event Action<ProjectData> ProjectStarted;
        public static event Action<string> BuyProgrammerIntent;

        public static void CompleteWriteCode() => CodeWrittenComplete?.Invoke();
        public static void WriteCode() => CodeWritten?.Invoke();
        public static void ChangeMoneyCount(long amount, ChangeMoneyCountSystem changeMoneyCountSystem) => MoneyCountChanged?.Invoke(amount);
        public static void AccelerateCoding() => OnCodingAccelerated?.Invoke();
        public static void CreateMoney(GameObject money) => MoneyCreated?.Invoke(money);
        public static void CreateFurniture(FurnitureSlotType type, GameObject furniture) => FurnitureCreated?.Invoke(type, furniture);
        public static void IntentToRunProject(ProjectData projectData) => RunProjectIntent?.Invoke(projectData);
        public static void RunProject(ProjectData projectData) => ProjectStarted?.Invoke(projectData);
        public static void IntentChangeMoney(long amount) => ChangeMoneyIntent?.Invoke(amount);

        public static void IntentToBuyProgrammer(string automatedProjectName) =>  BuyProgrammerIntent?.Invoke(automatedProjectName);
    }
}