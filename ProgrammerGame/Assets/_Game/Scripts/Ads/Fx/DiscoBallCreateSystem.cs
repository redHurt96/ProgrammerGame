using _Game.Common;
using _Game.Configs;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Ads.Fx
{
    public class DiscoBallCreateSystem : BaseInitSystem
    {
        private GameObject _discoBallResource;
        private Transform _houseRoot;
        private AdsEvents _adsEvents;
        private GameObject _currentDiscoBall;

        public override void Init()
        {
            _discoBallResource = Services.Get<Settings>().FX.DiscoBall;
            _houseRoot = Services.Get<SceneObjects>().HouseRoot;
            _adsEvents = Services.Get<EventsMediator>().Ads;

            _adsEvents.OnCoffeeBreakStart += Create;
            _adsEvents.OnCoffeeBreakComplete += Destroy;
        }

        public override void Dispose()
        {
            if (_adsEvents == null)
                return;
            
            _adsEvents.OnCoffeeBreakStart -= Create;
            _adsEvents.OnCoffeeBreakComplete -= Destroy;
        }

        private void Create() => 
            _currentDiscoBall = Object.Instantiate(_discoBallResource, _houseRoot);

        private void Destroy() => 
            Object.Destroy(_currentDiscoBall);
    }
}