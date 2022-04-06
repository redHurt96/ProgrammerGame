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
    }
}