using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreateProgrammerSystem : BaseInitSystem
    {
        private readonly Apartment _apartment;
        private readonly EventsMediator _eventsMediator;
        private readonly GameData _data;
        private readonly Settings _settings;

        public CreateProgrammerSystem()
        {
            _apartment = Services.Get<Apartment>();
            _eventsMediator = Services.Get<EventsMediator>();
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
        }

        public override void Init()
        {
            CreateMainCharacter();
            CreateExistedProgrammers();

            _eventsMediator.BuyProgrammerIntent += CreateProgrammer;
        }

        public override void Dispose() => 
            _eventsMediator.BuyProgrammerIntent -= CreateProgrammer;

        private void CreateMainCharacter() => 
            _apartment.AddMainCharacter(_settings.MainCharacter);

        private void CreateExistedProgrammers()
        {
            foreach (RunProjectProcess runnedProject in _data.RunnedProjects)
                CreateProgrammer(runnedProject.ProjectData.Name);
        }

        private void CreateProgrammer(string projectName)
        {
            AllProgrammersSettings.ProgrammerWorkplace workplace =
                _settings.AllProgrammersSettings.Workplaces
                    .First(x => x.ProgrammerSettings.AutomatedProject.Name == projectName);

            _apartment.AddProgrammer(projectName, workplace.FurnitureSlot);
        }
    }
}