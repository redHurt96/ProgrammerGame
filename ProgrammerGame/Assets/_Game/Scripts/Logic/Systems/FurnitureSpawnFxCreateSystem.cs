using _Game.Common;
using _Game.Configs;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class FurnitureSpawnFxCreateSystem : BaseInitSystem
    {
        private readonly EventsMediator _eventsMediator;
        private readonly GameObject _resource;

        public FurnitureSpawnFxCreateSystem()
        {
            _eventsMediator = Services.Get<EventsMediator>();
            _resource = Services.Get<Settings>().FX.FurnitureSpawnFxPrefab;
        }

        public override void Init() => 
            _eventsMediator.ApartmentObjectSpawned += CreateFx;

        public override void Dispose() => 
            _eventsMediator.ApartmentObjectSpawned -= CreateFx;

        private void CreateFx(Vector3 position) => 
            Object.Instantiate(_resource, position, Quaternion.identity);
    }
}