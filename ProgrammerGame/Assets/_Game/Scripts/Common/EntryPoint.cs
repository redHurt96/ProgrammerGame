using _Game.Ads.Fx;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.Systems;
using _Game.GameServices;
using _Game.GameServices.Analytics;
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

        private static IAdsService _adsService;

        protected override void RegisterServices()
        {
            if (EventsMediator.Instance != null)
                EventsMediator.DestroyInstance();

            _services
                .RegisterSingle(_settings)
                .RegisterSingle(_sceneObjects)
                .RegisterSingle(_tutorialSettings)
                .RegisterSingle(new WindowsManager())
                .RegisterSingle(new Apartment())
                .RegisterSingle(new EventsMediator())
                .RegisterSingle(new GameData())
                .RegisterSingle(new TutorialEvents())
                .RegisterSingle(new AnalyticsService())
                .RegisterSingle(CreateAdsService());
        }

        protected override void RegisterSystems() =>
            _systems

                //logic
                .Add(new SaveLoadSystem())
                .Add(new PersistentDataSaveLoadSystem())
                .Add(new IncreaseSessionsCountSystem())
                .Add(new ResetBoostAddendVariableInitializeSystem())
                .Add(new ResetForBoostSystem())
                .Add(new UpdateProjectAvailabilitySystem())
                .Add(new RunProjectSystem())
                .Add(new AddMoneyForProjectSystem())
                .Add(new ChangeMoneyCountSystem())
                .Add(new BuyProgrammerSystem())
                .Add(new BuyUpgradeSystem())
                .Add(new CreateDefaultInteriorSystem())
                .Add(new CreateInteriorSystem())
                .Add(new CreatePCSystem())
                .Add(new CreateHouseSystem())
                .Add(new CreateProgrammerSystem())
                .Add(new UpgradeProgrammersSystem())
                .Add(new UpdateProjectsAfterUpgradeSystem())
                .Add(new IdleIncomeSystem())
                .Add(new AddMoneyForTapSystem())
                .Add(new AddStartMoneySystem())
                .Add(new AddCurrentMoneySystem())
                .Add(new ShowNewLevelButtonSystem())
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
                .Add(new TutorialResetForBoostStep())

                //ads
                .Add(new AdsOnPauseEventProvider())
                .Add(new InterstitialAdSystem())
                .Add(new CoffeeBreakAdSystem())
                .Add(new RewardForLevelAdSystem())
                //.Add(new LoadAdvBannerSystem())

                //notifications
                .Add(new NotificationsSaveSystem())
                .Add(new NotificationsSystem())

#if DEVELOPMENT_BUILD
                .Add(new TestNotificationSystem())
#endif

                //fx
                .Add(new TapFxCreateSystem())
                .Add(new FurnitureSpawnFxCreateSystem())
                .Add(new PizzaCreateSystem())
                .Add(new DiscoBallCreateSystem())

                //must be the last
                .Add(new ChangeGameStateToPlaySystem());

        private void Update() => 
            _systems.Update();

        private void OnDestroy()
        {
            _systems.Dispose();
            
            Services.DestroyInstance();
            GameData.DestroyInstance();
        }

        private IAdsService CreateAdsService() => _adsService ??= new ApplovinAdsService();
    }
}