using _Game.UI.Tutorial;
using RH.Utilities.SingletonAccess;

namespace _Game.Configs
{
    public class TutorialSettings : MonoBehaviourSingleton<TutorialSettings>
    {
        public TutorialWindow[] Windows;
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
    }
}