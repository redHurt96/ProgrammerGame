using System;
using _Game.Logic.Data;
using AP.ProgrammerGame.Logic;
using UnityEngine;

namespace AP.ProgrammerGame
{
    public static class GlobalEvents
    {
        public static event Action CodeWrittenComplete;
        public static event Action CodeWritten;
        public static event Action BugCatched;
        public static event Action<int> MoneyCountChanged;
        public static event Action OnCodingAccelerated;
        public static event Action<GameObject> MoneyCreated;
        public static event Action<FurnitureSlotType, GameObject> FurnitureCreated;
        public static event Action BuyDeveloperCompleted;
        public static event Action<ProjectData> RunProjectIntent;
        public static event Action<ProjectData> ProjectRunned;

        public static void CompleteWriteCode() => CodeWrittenComplete?.Invoke();
        public static void WriteCode() => CodeWritten?.Invoke();
        public static void CatchBug() => BugCatched?.Invoke();
        public static void ChangeMoneyCount(int amount) => MoneyCountChanged?.Invoke(amount);
        public static void AccelerateCoding() => OnCodingAccelerated?.Invoke();
        public static void CreateMoney(GameObject money) => MoneyCreated?.Invoke(money);
        public static void CreateFurniture(FurnitureSlotType type, GameObject furniture) => FurnitureCreated?.Invoke(type, furniture);
        public static void UpdateMoneyCount() => ChangeMoneyCount(0);
        public static void BuyDeveloperComplete() => BuyDeveloperCompleted?.Invoke();
        public static void IntentRunProject(ProjectData projectData) => RunProjectIntent?.Invoke(projectData);

        public static void RunProject(ProjectData projectData) => ProjectRunned?.Invoke(projectData);
    }
}