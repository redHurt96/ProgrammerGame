using _Game.UI.Tutorial;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Tutorial
{
    public class TutorialSettings : MonoBehaviourSingleton<TutorialSettings>, IService
    {
        public TutorialWindow[] Windows;
        public GameObject Background;
    }

    public enum TutorialStep
    {
        BuyFirstProject_1,
        PerformFirstProject_2,
        TapForMoney_3,
        BuyFirstProgrammer_4,
        UpgradeProject_5,
        BuyAnotherProject_6,
        UpgradePcOrFurniture_7,
        BuyEnoughFurniture_8,
        UpgradeHouse_9,

        GoToProgrammersTab_4_0,
        GoToUpgradesTab_7_0,
    }
}