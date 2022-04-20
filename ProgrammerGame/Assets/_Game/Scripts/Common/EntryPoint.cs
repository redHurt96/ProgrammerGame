using System;
using System.Collections;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.Systems;
using _Game.Services;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Common
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Settings _settings;

        private SystemsArray _systems;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _settings.CreateInstance();

            if (GlobalEvents.Instance != null)
                GlobalEvents.DestroyInstance();

            new GlobalEvents();

            new SettingsPresenter();

            new GameData();
            new GameDataPresenter();
            new Apartment();
            new TutorialEvents();

            _systems = new SystemsArray()

                //game logic
                .Add(new SaveLoadSystem())
                .Add(new ResetForBoostSystem())
                .Add(new UpdateProjectAvailabilitySystem())
                .Add(new RunProjectSystem())
                .Add(new AddMoneyForProjectSystem())
                .Add(new ChangeMoneyCountSystem())
                .Add(new BuyProgrammerSystem())
                .Add(new AddMoneyForTapSystem())
                .Add(new BuyUpgradeSystem())
                .Add(new CreateRoomsSystem())
                .Add(new CreateInteriorSystem())
                .Add(new CreatePcSystem())
                .Add(new UpdateProjectsAfterUpgradeSystem())
                .Add(new IdleIncomeSystem())
                .Add(new CreateProgrammerSystem())
                .Add(new AddStartMoneySystem())
                .Add(new AddCurrentMoneySystem())

                .Add(new PersistentDataSaveLoadSystem())
                .Add(new ShowLevelWindowSystem())

                .Add(new DailyBonusSaveLoadSystem())
                .Add(new DailyBonusUpdateSystem())
                .Add(new DailyBonusShowWindowSystem())

                //tutorial
                .Add(new TutorialsSaveSystem())
                .Add(new TutorialCreateSystem())

                .Add(new TutorialBuyFirstProjectStep())
                .Add(new TutorialRunFirstProjectStep())
                .Add(new TutorialTapMoneyStepHandleSystem())
                .Add(new TutorialBuyFirstProgrammerStep())
                .Add(new TutorialUpgradeProjectStep())
                .Add(new TutorialBuyAnotherProjectStep())
                .Add(new TutorialUpgradePcStep())
                .Add(new TutorialBuyEnoughFurnitureStep())
                .Add(new TutorialUpgradeHouseStep())

                //fx
                .Add(new TapFxCreateSystem())
                .Add(new FurnitureSpawnFxCreateSystem())

                .Add(new UpdatePlayerLevelSystem())

                //must be the last
                .Add(new ChangeGameStateToPlaySystem())

                .Init();
        }

        private void Update() => 
            _systems.Update();

        private void OnDestroy()
        {
            _systems.Dispose();

            _settings.DestroyInstance();

            SettingsPresenter.DestroyInstance();
            GameDataPresenter.DestroyInstance();
            Apartment.DestroyInstance();
            TutorialEvents.DestroyInstance();
            GameData.DestroyInstance();
        }
    }
}