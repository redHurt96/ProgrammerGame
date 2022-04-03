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
            _settings.CreateInstance();
            _furnitureRefs.CreateInstance();

            new GameData();

            _systems = new SystemsArray()
                
                //game logic
                .Add(new SaveLoadSystem())
                .Add(new UpdateProjectAvailabilitySystem())
                .Add(new RunProjectSystem())
                .Add(new AddMoneyForProjectSystem())

                //fx
                .Add(new TapFxCreateSystem())

                .Init();

            new CodeWritingProcess();
            new Wallet();
            new CodeWritingAccelerator();
            new MoneyStorage();
            new FurnitureStorage();
            new BaseHouseSpawnSystem();
            new HouseUpgradeManager();
        }

        private void OnDestroy() => 
            _systems.Dispose();
    }
}