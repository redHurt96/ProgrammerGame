using AP.ProgrammerGame.Logic;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame
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