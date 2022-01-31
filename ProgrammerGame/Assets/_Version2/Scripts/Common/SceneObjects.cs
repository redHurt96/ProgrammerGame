using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    public class SceneObjects : MonoBehaviourSingleton<SceneObjects>
    {
        public Transform MoneyParentObject;
        public Transform HouseParentObject;
    }
}