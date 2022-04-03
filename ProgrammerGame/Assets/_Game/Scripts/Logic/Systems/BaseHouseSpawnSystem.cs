using _Game.Configs;

namespace AP.ProgrammerGame.Logic
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