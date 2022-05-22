using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class UpgradeProgrammersSystem : BaseInitSystem
    {
        private readonly GameData _data;
        private readonly GlobalEvents _events;
        private readonly Apartment _apartment;
        private readonly Settings _setting;

        public UpgradeProgrammersSystem()
        {
            _data = Services.Get<GameData>();
            _events = Services.Get<GlobalEvents>();
            _apartment = Services.Get<Apartment>();
            _setting = Services.Get<Settings>();
        }
        
        public override void Init()
        {
            _events.UpgradeProgrammerIntent += UpgradeProgrammer;

            SetupExistedProgrammers();
        }

        public override void Dispose() => 
            _events.UpgradeProgrammerIntent -= UpgradeProgrammer;

        private void UpgradeProgrammer(string projectName)
        {
            ProgrammerUpgradeData programmer = _data.GetProgrammerData(projectName);
            ProjectData project = _data.GetProject(projectName);

            UpgradeProgrammerSetup(projectName, programmer.Level);

            project.ForceUpdate();
            programmer.Upgrade();
        }

        private void UpgradeProgrammerSetup(string projectName, int level)
        {
            FurnitureSlot slot = _setting.AllProgrammersSettings.Upgrades[level];

            _apartment.AddProgrammerUpgrade(projectName, slot);
        }

        private void SetupExistedProgrammers()
        {
            foreach (ProgrammerUpgradeData upgradeData in _data.SavableData.AutoRunnedProjects)
            {
                for (int i = 0; i < upgradeData.Level; i++)
                    UpgradeProgrammerSetup(upgradeData.ProjectName, i);
            }
        }
    }
}