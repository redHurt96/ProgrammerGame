using System.Collections;
using _Game.Common;
using _Game.Configs;
using RH.Utilities;
using RH.Utilities.Coroutines;
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

        private float _spawnTime;
        private Coroutine _currentCoroutine;

        public override void Init()
        {
            _pizzaResource = Services.Get<Settings>().FX.Pizza;
            _spawnTime = Services.Get<Settings>().FX.PizzaSpawnTime;
            SceneObjects sceneObjects = Services.Get<SceneObjects>();
            CreateRoot(sceneObjects);
            _spawnZone = sceneObjects.PizzaSpawnZone;
            _adsEvents = Services.Get<EventsMediator>().Ads;
            _pool = new GameObjectsPool(_pizzaResource, _pizzaRoot);

            _adsEvents.OnCoffeeBreakStart += StartPizzaCreating;
            _adsEvents.OnCoffeeBreakComplete += ClearAllPizzas;
        }

        private void StartPizzaCreating()
        {
            ClearCurrentCoroutine();
            _currentCoroutine = CoroutineLauncher.Start(Creating());
        }

        private IEnumerator Creating()
        {
            while (Application.isPlaying)
            {
                yield return new WaitForSeconds(_spawnTime);
                CreatePizza();
            }
        }

        public override void Dispose()
        {
            if (_adsEvents == null)
                return;

            _adsEvents.OnCoffeeBreakStart -= StartPizzaCreating;
            _adsEvents.OnCoffeeBreakComplete -= ClearAllPizzas;
        }

        private void CreateRoot(SceneObjects sceneObjects)
        {
            _pizzaRoot = new GameObject("PizzaRoot").transform;
            _pizzaRoot.SetParent(sceneObjects.HouseRoot);
        }

        private void CreatePizza()
        {
            var pizza = _pool.Get();
            pizza.transform.position = _spawnZone.GetPoint();
        }

        private void ClearAllPizzas()
        {
            ClearCurrentCoroutine();
            _pool.ReturnAll();
        }

        private void ClearCurrentCoroutine()
        {
            if (_currentCoroutine != null)
                CoroutineLauncher.Stop(_currentCoroutine);
        }
    }
}
