using System;
using _Game.Data;
using _Game.Logic.Systems;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Common
{
    public class GlobalEvents : Singleton<GlobalEvents>, IService
    {
        public event Action<double> ChangeMoneyIntent;
        public event Action<double> MoneyCountChanged;
        public event Action<string> OnTapForMoney;
        public event Action<ProjectData> RunProjectIntent;
        public event Action<ProjectData> ProjectStarted;
        public event Action<string> BuyProgrammerIntent;
        public event Action<string> UpgradeProgrammerIntent;
        public event Action<UpgradeType, double> BuyUpgradeIntent;
        public event Action<UpgradeType> OnUpgraded;
        public event Action ResetForBoostIntent;
        public event Action BuyCountChanged;
        public event Action LevelChanged;
        public event Action ProgrammedPurchased;
        public event Action<Vector3> ApartmentObjectSpawned;
        public event Action DailyBonusUpdated;
        public event Action ApplicationPaused;
        public event Action<bool> ApplicationPausedWIthStatus;
        public event Action TutorialStepReceived;
        public event Action RewardedAdsShown;

        public void ChangeMoneyCount(double amount, IChangeMoneySystem changeMoneyCountSystem) => MoneyCountChanged?.Invoke(amount);
        public void AccelerateCoding(string value) => OnTapForMoney?.Invoke(value);
        public void IntentToRunProject(ProjectData projectData) => RunProjectIntent?.Invoke(projectData);
        public void RunProject(ProjectData projectData) => ProjectStarted?.Invoke(projectData);
        public void IntentToChangeMoney(double amount) => ChangeMoneyIntent?.Invoke(amount);
        public void IntentToBuyProgrammer(string automatedProjectName) =>  BuyProgrammerIntent?.Invoke(automatedProjectName);
        public void IntentToUpgradeProgrammer(string automatedProjectName) => UpgradeProgrammerIntent?.Invoke(automatedProjectName);

        public void IntentToBuyUpgrade(UpgradeType upgradeType, double price) => BuyUpgradeIntent?.Invoke(upgradeType, price);
        public void InvokeAfterUpgradeEvent(UpgradeType type) => OnUpgraded?.Invoke(type);
        public void ResetForBoost() => ResetForBoostIntent?.Invoke();
        public void InvokeChangeBuyCountsEvent() => BuyCountChanged?.Invoke();
        public void InvokeChangeLevelEvent() => LevelChanged?.Invoke();
        public void InvokeOnBuyProgrammerEvent() => ProgrammedPurchased?.Invoke();
        public void PerformOnFurnitureSpawned(Vector3 position) => ApartmentObjectSpawned?.Invoke(position);
        public void InvokeOnDailyBonusUpdate() => DailyBonusUpdated?.Invoke();

        public void InvokeOnApplicationPause() => ApplicationPaused?.Invoke();
        public void InvokeOnApplicationPause(bool pause) => ApplicationPausedWIthStatus?.Invoke(pause);
        public void InvokeOnTutorialStepReceiveEvent() => TutorialStepReceived?.Invoke();
        public void InvokeOnRewardedAdsShown() => RewardedAdsShown?.Invoke();
    }
}