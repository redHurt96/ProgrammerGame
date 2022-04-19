using _Game.Common;
using _Game.Configs;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class FurnitureSpawnFxCreateSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.Instance.ApartmentObjectSpawned += CreateFx;

        public override void Dispose() => 
            GlobalEvents.Instance.ApartmentObjectSpawned -= CreateFx;

        private void CreateFx(Vector3 position) => 
            Object.Instantiate(Settings.Instance.FurnitureSpawnFxPrefab, position, Quaternion.identity);
    }
}