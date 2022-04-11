using System.Collections;
using _Game.Configs;
using _Game.Logic.Systems;
using _Game.Services;
using AP.ProgrammerGame;
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

            _systems = new SystemsArray()

                //game logic
                .Add(new SaveLoadSystem())
                .Add(new ResetForBoostSystem())
                .Add(new UpdateProjectAvailabilitySystem())
                .Add(new RunProjectSystem())
                .Add(new AddMoneyForProjectSystem())
                .Add(new ChangeMoneyCountSystem())
                .Add(new MoneyStorageSystem())
                .Add(new BuyProgrammerSystem())
                .Add(new CodeWritingProcessSystem())
                .Add(new AddMoneyForTapSystem())
                .Add(new CodeWritingAccelerationSystem())
                .Add(new BuyUpgradeSystem())
                .Add(new CreateRoomsSystem())
                .Add(new CreateInteriorSystem())
                .Add(new CreatePcSystem())
                .Add(new UpdateProjectsAfterUpgradeSystem())
                .Add(new IdleIncomeSystem())
                .Add(new CreateProgrammerSystem())
                .Add(new CameraFlyAwaySystem())

                //fx
                .Add(new TapFxCreateSystem())

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

            SettingsPresenter.DestroyInstance();

            GameData.DestroyInstance();
            GameDataPresenter.DestroyInstance();
            Apartment.DestroyInstance();
        }
    }
}