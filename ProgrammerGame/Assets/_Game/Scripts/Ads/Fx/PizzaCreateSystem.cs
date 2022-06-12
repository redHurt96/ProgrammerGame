using _Game.Common;
using _Game.Configs;
using RH.Utilities;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Ads.Fx
{
    public class PizzaCreateSystem : BaseInitSystem
    {
        private GameObject _pizzaResource;
        private Transform _pizzaRoot;
        private AdsEvents _adsEvents;
        private GameObjectsPool _pool;
        private SpawnZone _spawnZone;

        public override void Init()
        {
            _pizzaResource = Services.Get<Settings>().FX.Pizza;
            SceneObjects sceneObjects = Services.Get<SceneObjects>();
            CreateRoot(sceneObjects);
            _spawnZone = sceneObjects.PizzaSpawnZone;
            _adsEvents = Services.Get<EventsMediator>().Ads;
            _pool = new GameObjectsPool(_pizzaResource, _pizzaRoot);
            
            _adsEvents.OnCoffeeBreakTimerUpdated += CreatePizza;
            _adsEvents.OnCoffeeBreakComplete += ClearAllPizzas;
        }

        public override void Dispose()
        {
            _adsEvents.OnCoffeeBreakTimerUpdated -= CreatePizza;
            _adsEvents.OnCoffeeBreakComplete -= ClearAllPizzas;
        }

        private void CreateRoot(SceneObjects sceneObjects)
        {
            _pizzaRoot = new GameObject("PizzaRoot").transform;
            _pizzaRoot.SetParent(sceneObjects.HouseRoot);
        }

        private void CreatePizza(float obj)
        {
            var pizza = _pool.Get();
            pizza.transform.position = _spawnZone.GetPoint();
        }

        private void ClearAllPizzas() => 
            _pool.ReturnAll();
    }
}
