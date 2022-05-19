﻿using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class CreateProgrammerSystem : BaseInitSystem
    {
        private readonly Apartment _apartment;

        public CreateProgrammerSystem()
        {
            _apartment = Services.Get<Apartment>();
        }
        
        public override void Init()
        {
            CreateMainCharacter();
            CreateExistedProgrammers();

            GlobalEvents.Instance.BuyProgrammerIntent += CreateProgrammer;
        }

        public override void Dispose() => 
            GlobalEvents.Instance.BuyProgrammerIntent -= CreateProgrammer;

        private void CreateMainCharacter() => 
            _apartment.AddMainCharacter(Settings.Instance.MainCharacter);

        private void CreateExistedProgrammers()
        {
            foreach (RunProjectProcess runnedProject in GameData.Instance.RunnedProjects)
                CreateProgrammer(runnedProject.ProjectData.Name);
        }

        private void CreateProgrammer(string projectName)
        {
            AllProgrammersSettings.ProgrammerWorkplace workplace =
                Settings.Instance.AllProgrammersSettings.Workplaces
                    .First(x => x.ProgrammerSettings.AutomatedProject.Name == projectName);

            _apartment.AddProgrammer(projectName, workplace.FurnitureSlot);
        }
    }
}