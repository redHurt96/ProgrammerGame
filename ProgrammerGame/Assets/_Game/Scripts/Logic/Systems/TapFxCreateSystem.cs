using _Game.Common;
using _Game.Configs;
using _Game.Fx;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TapFxCreateSystem : BaseInitSystem
    {
        private readonly EventsMediator _eventsMediator;
        private readonly SceneObjects _sceneObjects;
        private readonly PriceFx _fx;
        private readonly GameObject _fx2;

        public TapFxCreateSystem()
        {
            _eventsMediator = Services.Get<EventsMediator>();
            _sceneObjects = Services.Get<SceneObjects>();

            Settings settings = Services.Get<Settings>();
            _fx = settings.FX.TapFxPrefab;
            _fx2 = settings.FX.TapFxPrefab2;
        }

        public override void Init() => 
            _eventsMediator.OnTapForMoney += CreateFx;

        public override void Dispose() => 
            _eventsMediator.OnTapForMoney -= CreateFx;

        private void CreateFx(string value)
        {
            CreatePriceFx(value);
            CreateSecondFx();
        }

        private void CreatePriceFx(string value)
        {
            Vector3 position = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f); 
            PriceFx fx = Object.Instantiate(_fx, _sceneObjects.FxCanvas);
            fx.SetPrice(value);
            fx.transform.localPosition = position;
            Object.Destroy(fx.gameObject, 1f);
        }

        private void CreateSecondFx()
        {
            Vector3 position = _sceneObjects.Camera.ScreenToWorldPoint(Input.mousePosition);
            GameObject fx = Object.Instantiate(_fx2);
            fx.transform.localPosition = position;
            Object.Destroy(fx.gameObject, 1f);
        }
    }
}