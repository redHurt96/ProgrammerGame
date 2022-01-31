using AP.ProgrammerGame_v2.Logic;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private FurnitureRefs _furnitureRefs;

        private void Awake()
        {
            _settings.CreateInstance();
            _furnitureRefs.CreateInstance();

            new GameData();
            new CodeWritingProcess();
            new Wallet();
            new CodeWritingAccelerator();
            new MoneyStorage();
            new FurnitureStorage();
            new BaseHouseSpawnSystem();
        }
    }
}