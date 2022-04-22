using _Game.Common;
using _Game.Configs;
using _Game.Fx;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class TapFxCreateSystem : BaseInitSystem
    {
        private readonly GlobalEventsService _globalEvents;
        private readonly Settings _settings;

        public TapFxCreateSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _settings = Services.Instance.Single<Settings>();
        }

        public override void Init() => 
            _globalEvents.OnTapForMoney += CreateFx;

        public override void Dispose() => 
            _globalEvents.OnTapForMoney -= CreateFx;

        private void CreateFx(string value)
        {
            Vector3 position = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f); 
            PriceFx fx = Object.Instantiate(_settings.TapFxPrefab, SceneObjects.Instance.FxCanvas);
            fx.SetPrice(value);
            fx.transform.localPosition = position;
            Object.Destroy(fx.gameObject, 1f);
        }
    }
}