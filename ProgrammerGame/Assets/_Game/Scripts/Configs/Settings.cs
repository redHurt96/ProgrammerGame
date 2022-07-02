using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/Settings", order = 0)]
    public class Settings : SingletonScriptableObject<Settings>, IService
    {
        public FxConfigs FX;

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
        public InteriorSettings Interior;
        public AllProgrammersSettings AllProgrammersSettings;
        public FurnitureSlot MainCharacter;
        public PriceSettingsScriptable PcPrices;
        public PriceSettingsScriptable HousePrices;

        [Header("Boost for progress reset")]
        public float BoostForResetBaseValue;
        public float OpenResetThreshold = .5f;

        [Header("Daily bonus")]
        public float DailyBonusPerDay = .5f;

        [Header("Level reward")]
        public long TimeForLevelReward = 120;
        public float MinLevelReward;

        [Header("Project panel")]
        public double ChangeProgressBarAnchorTime = .1f;
        public float MinProjectTime = .23f;

        public AdsSettings Ads;
        public NotificationsSettings Notifications;
    }
}