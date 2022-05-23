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
        private readonly GlobalEvents _events;
        private readonly SceneObjects _sceneObjects;
        private readonly Settings _settings;

        public TapFxCreateSystem()
        {
            _events = Services.Get<GlobalEvents>();
            _sceneObjects = Services.Get<SceneObjects>();
            _settings = Services.Get<Settings>();
        }

        public override void Init() => 
            _events.OnTapForMoney += CreateFx;

        public override void Dispose() => 
            _events.OnTapForMoney -= CreateFx;

        private void CreateFx(string value)
        {
            CreatePriceFx(value);
            CreateSecondFx();
        }

        private void CreatePriceFx(string value)
        {
            Vector3 position = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f); 
            PriceFx fx = Object.Instantiate(_settings.TapFxPrefab, _sceneObjects.FxCanvas);
            fx.SetPrice(value);
            fx.transform.localPosition = position;
            Object.Destroy(fx.gameObject, 1f);
        }

        private void CreateSecondFx()
        {
            Vector3 position = _sceneObjects.Camera.ScreenToWorldPoint(Input.mousePosition);
            GameObject fx = Object.Instantiate(_settings.TapFxPrefab2);
            fx.transform.localPosition = position;
            Object.Destroy(fx.gameObject, 1f);
        }
    }
}