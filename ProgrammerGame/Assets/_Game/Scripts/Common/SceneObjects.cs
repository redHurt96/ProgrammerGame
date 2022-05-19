using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Common
{
    public class SceneObjects : MonoBehaviourSingleton<SceneObjects>, IService
    {
        public Transform MoneyParentObject;
        public Transform HouseParent;

        [Space] 
        public Transform FxCanvas;

        [Space] 
        public Camera Camera;

        [Space] 
        public EarnedWhileAwayWindow EarnedWhileAwayWindow;
        public DailyBonusWindow DailyBonusWindow;
        public LevelRewardWindow LevelWindow;
        public ResetWindow ResetWindow;
    }
}