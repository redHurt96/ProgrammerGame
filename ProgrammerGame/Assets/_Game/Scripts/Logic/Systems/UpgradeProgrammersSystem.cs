using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class UpgradeProgrammersSystem : BaseInitSystem
    {
        private readonly GameData _data;
        private readonly GlobalEvents _events;

        public UpgradeProgrammersSystem()
        {
            _data = Services.Get<GameData>();
            _events = Services.Get<GlobalEvents>();
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
            programmer.Upgrade();
        }

        private void SetupExistedProgrammers()
        {
            
        }
    }
}