using UnityEngine;

namespace AP.ProgrammerGame.Logic
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