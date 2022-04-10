using _Game.Logic.MonoBehaviours;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Game/Settings", order = 0)]
    public class Settings : SingletonScriptableObject<Settings>
    {
        public Money[] MoneyPrefabs;
        public GameObject TapFxPrefab;

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
        
        [Header("Code writing process")]
        public float CodeWritingTime = 5f;
        public float AccelerationCodeProgressPercent = .05f;
        public float MoneyForTapPercent;

        [Header("Upgrades")]
        public float IncreaseSpeedEffectStrength;
        public float IncreaseMoneyEffectStrength;

        [Header("House")]
        public RoomSettings[] Rooms;
        public PcSettings PcSettings;
        public AllProgrammersSettings AllProgrammersSettings;
        public FurnitureSlot MainCharacter;
    }
}