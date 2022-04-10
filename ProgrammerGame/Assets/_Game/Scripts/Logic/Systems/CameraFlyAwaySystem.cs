using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class CameraFlyAwaySystem : BaseInitSystem
    {
        public override void Init()
        {
            FlyAwayIfHasSize();

            GlobalEvents.OnUpgraded += FlyAwayIfNeed;
        }

        public override void Dispose() => 
            GlobalEvents.OnUpgraded -= FlyAwayIfNeed;

        private void FlyAwayIfNeed(UpgradeType type)
        {
            if (type == UpgradeType.House)
                FlyAwayIfHasSize();
        }

        private void FlyAwayIfHasSize()
        {
            CameraSizesPerHouseLevel sizeForLevel = Settings.Instance.CameraSizesPerHouseLevel
                .FirstOrDefault(x => x.Level == GameDataPresenter.Instance.RoomLevel);

            if (sizeForLevel != null)
                SceneObjects.Instance.VirtualCamera.m_Lens.OrthographicSize = sizeForLevel.Size;
        }
    }
}