using _Game.UI.Windows;
using Cinemachine;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Common
{
    public class SceneObjects : MonoBehaviourSingleton<SceneObjects>
    {
        public Transform MoneyParentObject;
        public Transform HouseParent;

        [Space] 
        public Transform FxCanvas;

        [Space]
        public CinemachineVirtualCamera VirtualCamera;

        [Space] 
        public EarnedWhileAwayWindow EarnedWhileAwayWindow;
    }
}