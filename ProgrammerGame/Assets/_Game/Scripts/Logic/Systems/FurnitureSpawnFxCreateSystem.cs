using _Game.Common;
using _Game.Configs;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class FurnitureSpawnFxCreateSystem : BaseInitSystem
    {
        public FurnitureSpawnFxCreateSystem()
        {
        }

        public override void Init() => 
            _globalEvents.ApartmentObjectSpawned += CreateFx;

        public override void Dispose() => 
            _globalEvents.ApartmentObjectSpawned -= CreateFx;

        private void CreateFx(Vector3 position) => 
            Object.Instantiate(_settings.FurnitureSpawnFxPrefab, position, Quaternion.identity);
    }
}