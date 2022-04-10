using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class UpdateProjectsAfterUpgradeSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.OnUpgraded += UpdateProjects;

        public override void Dispose() => 
            GlobalEvents.OnUpgraded -= UpdateProjects;

        private void UpdateProjects(UpgradeType upgradeType)
        {
            foreach (ProjectData project in GameData.Instance.SavableData.Projects) 
                project.InvokeUpdateEvent();
        }
    }
}