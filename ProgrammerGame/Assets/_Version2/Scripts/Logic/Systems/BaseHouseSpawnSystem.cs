using UnityEngine;

namespace AP.ProgrammerGame_v2.Logic
{
    public class BaseHouseSpawnSystem
    {
        public BaseHouseSpawnSystem()
        {
            SpawnDefaultFurniture();
            SpawnDefaultPc();
        }

        private void SpawnDefaultFurniture()
        {
            foreach (FurnitureSlot slot in FurnitureRefs.Instance.DefaultFurniture)
                FurnitureSpawnSystem.Instantiate(slot);
        }

        private void SpawnDefaultPc() =>
            FurnitureSpawnSystem.Instantiate(FurnitureRefs.Instance.Computers[0]);
    }
}