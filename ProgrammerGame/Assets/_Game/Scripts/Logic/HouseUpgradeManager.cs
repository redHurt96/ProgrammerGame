using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class HouseUpgradeManager : BaseUpgradeManager<HouseUpgradeManager>
    {
        public HouseUpgradeManager(IUpgradeObjectManager objectsManager, AnimationCurve pricesCurve) : base(objectsManager, pricesCurve)
        {
        }
    }
}