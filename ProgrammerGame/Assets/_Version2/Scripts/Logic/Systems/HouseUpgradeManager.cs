using RH.Utilities.SingletonAccess;

namespace AP.ProgrammerGame_v2.Logic
{
    public class HouseUpgradeManager : Singleton<HouseUpgradeManager>
    {
        public void BuyFurniture()
        {
            FurnitureSlot currentFurnitureSlot = GetCurrentFurniture();
            RemoveOldFurniture(currentFurnitureSlot);
            FurnitureSpawnSystem.Instantiate(currentFurnitureSlot);
        }

        public void BuyPc()
        {
            FurnitureSlot currentFurnitureSlot = FurnitureRefs.Instance.Computers[GameData.Instance.PurchasedComputersCount];
            RemoveOldFurniture(currentFurnitureSlot);
            FurnitureSpawnSystem.Instantiate(currentFurnitureSlot);
        }

        private static FurnitureSlot GetCurrentFurniture()
        {
            int nextFurnitureIndex = GameData.Instance.PurchasedFurnitureCount;
            FurnitureSlot currentFurnitureSlot = FurnitureRefs.Instance.FurnitureToPurchase[nextFurnitureIndex];
            return currentFurnitureSlot;
        }

        private static void RemoveOldFurniture(FurnitureSlot currentFurnitureSlot)
        {
            if (currentFurnitureSlot.ReplacingTypes != null && currentFurnitureSlot.ReplacingTypes.Length > 0)
                FurnitureStorage.Instance.RemoveFurnitures(currentFurnitureSlot.ReplacingTypes);
        }
    }
}