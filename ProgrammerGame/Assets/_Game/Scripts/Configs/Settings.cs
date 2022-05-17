using System.Collections.Generic;
using System.Linq;
using _Game.Fx;
using _Game.Logic.MonoBehaviours;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/Settings", order = 0)]
    public partial class Settings : SingletonScriptableObject<Settings>
    {
        public Money[] MoneyPrefabs;
        public PriceFx TapFxPrefab;
        public GameObject FurnitureSpawnFxPrefab;

        [Header("Money spawning")]
        public float MoneyFallForce = 2f;
        public float MoneySpawnTime;
        public int MaxMoneySpawnCount = 50;
        public float MoneyBasementForce = 20f;
        public float MoneyBasementRandomizeForce = 100f;
        public float MoneyBasementSpawnDelay = .5f;
        public int MaxBasementMoneysCount = 500;

        [Space]
        public float MoneyRigidbodyRemoveTime = 3f;

        [Space]
        public int[] TargetLevels = {25, 50, 75, 100, 150, 200, 250, 300, 400, 500, 750, 1000};

        [Space]
        public ProjectSettings[] ProjectsSettings;

        [Space] 
        public long IdleIncomeSeconds;

        [Header("Start options")] 
        public long StartMoney;

        [Header("Upgrades")]
        public float IncreaseSpeedEffectStrength;
        public float IncreaseMoneyEffectStrength;
        [Space] 
        public PriceSettings MoneyForTap;

        [Header("House")]
        public RoomSettings[] Rooms;
        public PcSettings PcSettings;
        public AllProgrammersSettings AllProgrammersSettings;
        public FurnitureSlot MainCharacter;
        public PriceSettings PcUpgradeSettings;

        [Header("Camera")]
        public CameraSizesPerHouseLevel[] CameraSizesPerHouseLevel;

        [Header("Boost for progress reset")]
        public float BoostForResetBaseValue;
        public float OpenResetThreshold = .5f;

        [Header("Daily bonus")]
        public float DailyBonusPerDay = .5f;

        [Header("Level reward")]
        public long TimeForLevelReward = 120;
        public float MinLevelReward;
    }

    public partial class Settings
    {
        public List<Money> GetMoneysPrefabsList(double amount)
        {
            List<Money> moneysPrefabs = new List<Money>();

            while (amount > 0)
            {
                Money prefab = GetMoneyResourceByValue(amount);

                if (prefab == null || moneysPrefabs.Count >= Settings.Instance.MaxMoneySpawnCount)
                    break;

                moneysPrefabs.Add(prefab);

                amount -= prefab.Value;
            }

            return moneysPrefabs;
        }

        private Money GetMoneyResourceByValue(double amount) =>
            Settings.Instance.MoneyPrefabs.LastOrDefault(x => x.Value <= amount);

    }
}