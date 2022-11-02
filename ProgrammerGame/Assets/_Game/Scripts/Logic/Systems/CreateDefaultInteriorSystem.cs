using _Game.Configs;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CreateDefaultInteriorSystem : BaseInitSystem
    {
        private readonly Apartment _apartment;
        private readonly Settings _settings;

        public CreateDefaultInteriorSystem()
        {
            _apartment = Services.Get<Apartment>();
            _settings = Services.Get<Settings>();
        }
        
        public override void Init() => 
            CreateDefaultInteriors();

        public override void Dispose() {}

        private void CreateDefaultInteriors()
        {
            foreach (GameObject furniture in _settings.Interior.DefaultFurniture) 
                _apartment.AddFurniture(furniture);
        }
    }
}