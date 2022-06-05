using System.Collections;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.Coroutines;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class CoffeeBreakAdSystem : BaseInitSystem
    {
        private readonly GameData _data;
        private readonly GlobalEvents _events;
        private readonly AdsService _ads;
        private readonly Settings _settings;

        public CoffeeBreakAdSystem()
        {
            _ads = Services.Get<AdsService>();
            _data = Services.Get<GameData>();
            _events = Services.Get<GlobalEvents>();
            _settings = Services.Get<Settings>();
        }

        public override void Init()
        {
            _data.Ads.CanShowCoffeeBreak = true;
            _events.OnCoffeeBreakIntent += ShowAd;
        }

        public override void Dispose() => 
            _events.OnCoffeeBreakIntent -= ShowAd;

        private void ShowAd() => 
            _ads.ShowRewarded("CoffeeBreak", PerformOnAdComplete);

        private void PerformOnAdComplete()
        {
            //GiveReward
            UnityEngine.Debug.Log("Coffee break complete");

            CoroutineLauncher.Start(DelayUntilNewCoffeeBreak());

            _events.InvokeOnRewardedAdsShown();
        }

        private IEnumerator DelayUntilNewCoffeeBreak()
        {
            _data.Ads.CanShowCoffeeBreak = false;
            yield return new WaitForSeconds(_settings.Ads.CoffeeBreakLenght + _settings.Ads.CoffeeBreakDelay);
            _data.Ads.CanShowCoffeeBreak = true;
        }
    }
}