using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class House : MonoBehaviour
    {
        public Furniture[] Furnitures;
        public SpawnZone SpawnZone;

        public void DisableAll()
        {
            foreach (var furniture in Furnitures)
                furniture.Disable();
        }
    }
}