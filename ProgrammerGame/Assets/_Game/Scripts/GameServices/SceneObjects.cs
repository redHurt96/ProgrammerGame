using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Common
{
    public class SceneObjects : MonoBehaviourSingleton<SceneObjects>, IService
    {
        public Transform MoneyParentObject;
        public Transform HouseRoot;

        [Space] 
        public Transform FxCanvas;
        public SpawnZone PizzaSpawnZone;

        [Space] 
        public Camera Camera;

        [Space] 
        public EarnedWhileAwayWindow EarnedWhileAwayWindow;
        public DailyBonusWindow DailyBonusWindow;
        public LevelRewardWindow LevelWindow;
        public BaseWindow CoffeeBreakWindow;
        
        [Space]
        public GameObject NewLevelButton;
    }
}