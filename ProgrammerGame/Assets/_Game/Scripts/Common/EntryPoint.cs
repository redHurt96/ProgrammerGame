using _Game.Configs;
using _Game.Data;
using _Game.Logic.GameServices;
using _Game.Logic.Systems;
using _Game.Tutorial;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _Game.Common
{
    public class EntryPoint : AbstractEntryPoint
    {
        [SerializeField] private Settings _settings;

        private void Update() => 
            _systems.Update();

        protected override void RegisterServices() =>
            _services.RegisterSingle(_settings)
                .RegisterSingle(new GameData())
                .RegisterSingle(new GlobalEventsService())
                .RegisterSingle(new SettingsPresenter())
                .RegisterSingle(new GameDataPresenter())
                .RegisterSingle(new Apartment())
                .RegisterSingle(new TutorialEvents());

        protected override void RegisterSystems() =>
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
                .Add(new UpdateProjectsAfterUpgradeSystem())
                .Add(new IdleIncomeSystem())
                .Add(new AddMoneyForTapSystem())
                .Add(new CreateProgrammerSystem())
                .Add(new AddStartMoneySystem())
                .Add(new AddCurrentMoneySystem())
                .Add(new ShowLevelWindowSystem())
                .Add(new DailyBonusSaveLoadSystem())
                .Add(new DailyBonusUpdateSystem())
                .Add(new DailyBonusShowWindowSystem())
                //tutorial
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
                .Add(new ChangeGameStateToPlaySystem());
    }
}