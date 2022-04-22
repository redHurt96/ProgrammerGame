using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Logic.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreateProgrammerSystem : BaseInitSystem
    {
        private readonly Apartment _apartment;
        private readonly GlobalEventsService _globalEvents;
        private readonly Settings _settings;
        private readonly GameData _gameData;

        public CreateProgrammerSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _apartment = Services.Instance.Single<Apartment>();
            _settings = Services.Instance.Single<Settings>();
            _gameData = Services.Instance.Single<GameData>();
        }

        public override void Init()
        {
            CreateMainCharacter();
            CreateExistedProgrammers();

            _globalEvents.BuyProgrammerIntent += CreateProgrammer;
        }

        public override void Dispose() => 
            _globalEvents.BuyProgrammerIntent -= CreateProgrammer;

        private void CreateMainCharacter() => 
            _apartment.AddMainCharacter(_settings.MainCharacter);

        private void CreateExistedProgrammers()
        {
            foreach (RunProjectProcess runnedProject in _gameData.RunnedProjects)
                CreateProgrammer(runnedProject.ProjectData.Name);
        }

        private void CreateProgrammer(string name)
        {
            AllProgrammersSettings.ProgrammerWorkplace workplace =
                _settings.AllProgrammersSettings.Workplaces
                    .First(x => x.ProgrammerSettings.AutomatedProject.Name == name);

            _apartment.AddProgrammer(workplace.FurnitureSlot);
        }
    }
}