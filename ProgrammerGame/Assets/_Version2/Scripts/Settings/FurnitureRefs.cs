using AP.ProgrammerGame_v2.Logic;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    [CreateAssetMenu(fileName = "FurnitureRefs", menuName = "Game/V2/FurnitureRefs", order = 2)]
    public class FurnitureRefs : SingletonScriptableObject<FurnitureRefs>
    {
        public GameObject HouseBase;

        [Space]
        public FurnitureSlot[] DefaultFurniture;
        public FurnitureSlot[] FurnitureToPurchase;

        [Space]
        public FurnitureSlot[] Computers;
    }
}