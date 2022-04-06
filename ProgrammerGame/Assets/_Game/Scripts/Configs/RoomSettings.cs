using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Room settings", menuName = "Game/Room settings", order = 0)]
    public class RoomSettings : ScriptableObject
    {
        public GameObject Base;

        public FurnitureSlot[] DefaultFurniture;
        public FurnitureSlot[] FurnitureForPurchase;
        public ProgrammerSpot[] ProgrammerSpots;
    }
}