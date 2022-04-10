using System.Linq;
using _Game.Configs;
using _Game.Data;
using _Game.Services;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class CreateProgrammerSystem : BaseInitSystem
    {
        public override void Init()
        {
            CreateMainCharacter();
            CreateExistedProgrammers();

            GlobalEvents.BuyProgrammerIntent += CreateProgrammer;
        }

        public override void Dispose() => 
            GlobalEvents.BuyProgrammerIntent -= CreateProgrammer;

        private void CreateMainCharacter() => 
            Apartment.Instance.AddMainCharacter(Settings.Instance.MainCharacter);

        private void CreateExistedProgrammers()
        {
            foreach (RunProjectProcess runnedProject in GameData.Instance.RunnedProjects)
                CreateProgrammer(runnedProject.ProjectData.Name);
        }

        private void CreateProgrammer(string name)
        {
            AllProgrammersSettings.ProgrammerWorkplace workplace =
                Settings.Instance.AllProgrammersSettings.Workplaces
                    .First(x => x.ProgrammerSettings.AutomatedProject.Name == name);

            Apartment.Instance.AddProgrammer(workplace.FurnitureSlot);
        }
    }
}