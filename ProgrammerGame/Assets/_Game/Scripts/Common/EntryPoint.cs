using _Game.Configs;
using _Game.Logic.Systems;
using AP.ProgrammerGame;
using AP.ProgrammerGame.Logic;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Common
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private FurnitureRefs _furnitureRefs;

        private SystemsArray _systems;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _settings.CreateInstance();
            _furnitureRefs.CreateInstance();

            new GameData();

            _systems = new SystemsArray()
                
                //game logic
                .Add(new SaveLoadSystem())
                .Add(new UpdateProjectAvailabilitySystem())
                .Add(new RunProjectSystem())
                .Add(new AddMoneyForProjectSystem())
                .Add(new ChangeMoneyCountSystem())
                .Add(new MoneyStorageSystem())
                .Add(new BuyProgrammerSystem())

                //fx
                .Add(new TapFxCreateSystem())

                .Init();

            new CodeWritingProcess();
            new CodeWritingAccelerator();
            new MoneyStorageSystem();
            new FurnitureStorage();
            new BaseHouseSpawnSystem();
            new HouseUpgradeManager();
        }

        private void OnDestroy() => 
            _systems.Dispose();
    }
}