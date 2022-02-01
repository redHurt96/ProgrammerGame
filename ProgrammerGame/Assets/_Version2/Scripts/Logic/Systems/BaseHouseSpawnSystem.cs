namespace AP.ProgrammerGame_v2.Logic
{
    public class BaseHouseSpawnSystem
    {
        public BaseHouseSpawnSystem() => SpawnDefaultFurniture();

        private void SpawnDefaultFurniture()
        {
            foreach (FurnitureSlot slot in FurnitureRefs.Instance.DefaultFurniture)
                FurnitureSpawnSystem.Instantiate(slot);
        }
    }
}