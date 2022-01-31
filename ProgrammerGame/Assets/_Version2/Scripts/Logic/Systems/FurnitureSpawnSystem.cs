using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public static class FurnitureSpawnSystem
    {
        public static void Instantiate(FurnitureSlot slot)
        {
            GameObject furniture = Object.Instantiate(slot.Furniture, SceneObjects.Instance.HouseParentObject);
            GlobalEvents.CreateFurniture(slot.Type, furniture);
        }
    }
}