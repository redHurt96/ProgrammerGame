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
                .Add(new CameraFlyAwaySystem())
                .Add(new AddCurrentMoneySystem())
                .Add(new UpdatePlayerLevelSystem())

                //tutorial
                .Add(new PassedTutorialsSaveSystem())
                .Add(new TutorialCreateSystem())
                .Add(new TutorialFirstStepHandleSystem())
                .Add(new TutorialTapMoneyStepHandleSystem())
                .Add(new TutorialCanBuyMoreProjectsHandleSystem())

                //fx
                .Add(new TapFxCreateSystem())
                .Add(new FurnitureSpawnFxCreateSystem())

                //must be the last
                .Add(new ChangeGameStateToPlaySystem())

                .Init();
        }

        private IEnumerator Start()
        {
            yield return null;

            GlobalEvents.IntentToChangeMoney(Settings.Instance.StartMoney);
        }

        private void OnDestroy()
        {
            _systems.Dispose();

            _settings.DestroyInstance();

            SettingsPresenter.DestroyInstance();
            GameData.DestroyInstance();
            GameDataPresenter.DestroyInstance();
            Apartment.DestroyInstance();
            TutorialEvents.DestroyInstance();

            GlobalEvents.Clear();
        }
    }
}