using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class UpdateProjectsAfterUpgradeSystem : BaseInitSystem
    {
        public override void Init() => 
            EventsMediator.Instance.OnUpgraded += UpdateProjects;

        public override void Dispose() => 
            EventsMediator.Instance.OnUpgraded -= UpdateProjects;

        private void UpdateProjects(UpgradeType upgradeType)
        {
            foreach (ProjectData project in GameData.Instance.SavableData.Projects) 
                project.ForceUpdate();
        }
    }
}