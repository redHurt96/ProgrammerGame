using AP.ProgrammerGame_v2.Logic;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    public class SceneObjects : MonoBehaviourSingleton<SceneObjects>
    {
        public Transform MoneyParentObject;
        public Transform HouseParentObject;

        [Space]
        public CamerasPositionsArray CamerasPositionsArray;
        public RoomsSpawner roomsSpawner;
    }
}