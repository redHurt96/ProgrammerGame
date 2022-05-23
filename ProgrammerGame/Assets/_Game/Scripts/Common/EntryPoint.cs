using _Game.Configs;
using _Game.Data;
using _Game.Logic.Systems;
using _Game.GameServices;
using _Game.Tutorial;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Common
{
    public class EntryPoint : AbstractEntryPoint
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private SceneObjects _sceneObjects;
        [SerializeField] private TutorialSettings _tutorialSettings;

        protected override void RegisterServices()
        {
            _settings.CreateInstance();

            if (GlobalEvents.Instance != null)
                GlobalEvents.DestroyInstance();

            _services
                .RegisterSingle(_settings)
                .RegisterSingle(_sceneObjects)
                .RegisterSingle(_tutorialSettings)
                .RegisterSingle(new WindowsManager())
                .RegisterSingle(new Apartment())
                .RegisterSingle(new GlobalEvents())
                .RegisterSingle(new GameData())
                .RegisterSingle(new TutorialEvents());
        }

        protected override void RegisterSystems()
        {
            _systems

                //game logic
                .Add(new SaveLoadSystem())
                .Add(new PersistentDataSaveLoadSystem())
                .Add(new ResetForBoostSystem())
                .Add(new UpdateProjectAvailabilitySystem())
                .Add(new RunProjectSystem())
                .Add(new AddMoneyForProjectSystem())
                .Add(new ChangeMoneyCountSystem())
                .Add(new BuyProgrammerSystem())
                .Add(new BuyUpgradeSystem())
                .Add(new CreateRoomsSystem())
                .Add(new CreateInteriorSystem())
                .Add(new CreatePcSystem())
                .Add(new CreateProgrammerSystem())
                .Add(new UpgradeProgrammersSystem())
                .Add(new UpdateProjectsAfterUpgradeSystem())
                .Add(new IdleIncomeSystem())
                .Add(new AddMoneyForTapSystem())
                .Add(new AddStartMoneySystem())
                .Add(new AddCurrentMoneySystem())
                .Add(new ShowLevelWindowSystem())
                .Add(new UpdatePlayerLevelSystem())
                .Add(new DailyBonusSaveLoadSystem())
                .Add(new DailyBonusUpdateSystem())
                .Add(new DailyBonusShowWindowSystem())

                //tutorial
                .Add(new TutorialCreateSystem())
                .Add(new TutorialBuyFirstProjectStep_1())
                .Add(new TutorialRunFirstProjectStep_2())
                .Add(new TutorialTapMoneyStep_3())
                .Add(new TutorialUpgradeProjectStep_5())
                .Add(new TutorialBuyAnotherProjectStep_6())
                .Add(new TutorialGoToProgrammersTabStep_4_0())
                .Add(new TutorialBuyFirstProgrammerStep_4())
                .Add(new TutorialGoToUpgradesTabStep_7_0())
                .Add(new TutorialUpgradePcStep_7())
                .Add(new TutorialBuyEnoughFurnitureStep())
                .Add(new TutorialUpgradeHouseStep())
                .Add(new TutorialResetForBoostStep())

                //fx
                .Add(new TapFxCreateSystem())
                .Add(new FurnitureSpawnFxCreateSystem())

                //must be the last
                .Add(new ChangeGameStateToPlaySystem());
        }

        private void Update() => 
            _systems.Update();

        private void OnDestroy()
        {
            _systems.Dispose();
            Services.DestroyInstance();

            _settings.DestroyInstance();

            GameData.DestroyInstance();
            TutorialEvents.DestroyInstance();
            GameData.DestroyInstance();
        }
    }
}