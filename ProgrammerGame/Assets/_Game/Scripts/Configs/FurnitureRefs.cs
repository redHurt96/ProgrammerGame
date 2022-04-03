using AP.ProgrammerGame.Logic;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "FurnitureRefs", menuName = "Game/FurnitureRefs", order = 2)]
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