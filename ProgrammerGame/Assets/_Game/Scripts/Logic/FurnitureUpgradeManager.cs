using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class FurnitureUpgradeManager : BaseUpgradeManager<FurnitureUpgradeManager>
    {
        public FurnitureUpgradeManager(IUpgradeObjectManager objectsManager, AnimationCurve pricesCurve) : base(objectsManager, pricesCurve)
        {
        }
    }
}