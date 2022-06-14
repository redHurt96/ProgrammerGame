using System.Collections.Generic;
using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Interior settings", menuName = "Game/Interior settings", order = 0)]
    public class InteriorSettings : ScriptableObject
    {
        public GameObject[] DefaultFurniture;
        public List<FurnitureSlot2> FurnitureForPurchase;

#if UNITY_EDITOR
        
        public GameObject[] SetPurchasedFrom;

        [ContextMenu(nameof(SetPurchasedFurniture))]
        private void SetPurchasedFurniture()
        {
            foreach (GameObject gameObject in SetPurchasedFrom)
            {
                FurnitureForPurchase.Add(new FurnitureSlot2
                {
                    FurnitureToStand = new[] {gameObject},
                });

                SetPurchasedFrom = null;
            }
        }
        
#endif
    }
}