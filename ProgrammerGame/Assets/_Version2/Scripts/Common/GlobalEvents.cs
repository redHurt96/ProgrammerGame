using System;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    public static class GlobalEvents
    {
        public static event Action CodeWrittenComplete;
        public static event Action CodeWritten;

        public static event Action BugCatched;

        public static event Action<float> MoneyCountChanged;

        public static event Action OnCodingAccelerationIntent;
        public static event Action CodingAccelerated;

        public static event Action<GameObject> MoneyCreated;

        public static void CompleteWriteCode() => CodeWrittenComplete?.Invoke();
        public static void WriteCode() => CodeWritten?.Invoke();
        public static void CatchBug() => BugCatched?.Invoke();
        public static void AddMoney(float amount) => MoneyCountChanged?.Invoke(amount);
        public static void IntentAccelerateCoding() => OnCodingAccelerationIntent?.Invoke();
        public static void AccelerateCoding() => CodingAccelerated?.Invoke();
        public static void CreateMoney(GameObject money) => MoneyCreated?.Invoke(money);
    }
}