using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "PC settings", menuName = "Game/PC settings", order = 0)]
    public class PcSettings : ScriptableObject
    {
        public FurnitureSlot[] DefaultFurniture;
        public FurnitureSlot[] FurnitureForPurchase;
    }
}