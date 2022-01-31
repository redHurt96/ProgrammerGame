using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class BaseHouseSpawnSystem
    {
        public BaseHouseSpawnSystem()
        {
            SpawnStaticObjects();
            SpawnDefaultFurniture();
            SpawnDefaultPc();
        }

        private void SpawnStaticObjects() => 
            Object.Instantiate(FurnitureRefs.Instance.HouseBase, SceneObjects.Instance.StaticHouseParentObject);

        private void SpawnDefaultFurniture()
        {
            foreach (FurnitureSlot slot in FurnitureRefs.Instance.DefaultFurniture)
                Instantiate(slot, SceneObjects.Instance.HouseParentObject);
        }

        private void SpawnDefaultPc() => 
            Instantiate(FurnitureRefs.Instance.Computers[0], SceneObjects.Instance.HouseParentObject);

        private void Instantiate(FurnitureSlot slot, Transform toParent)
        {
            GameObject furniture = Object.Instantiate(slot.Furniture, toParent);
            GlobalEvents.CreateFurniture(slot.Type, furniture);
        }
    }
}