using System.Collections;
using _Game.Common;
using _Game.Configs;
using _Game.GameServices;
using _Game.GameServices.Analytics;
using RH.Utilities.Coroutines;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class InterstitialAdSystem : BaseInitSystem
    {
        private readonly Settings _settings;
        private readonly IAdsService _ads;
        private readonly AdsEvents _events;

        private Coroutine _currentCoroutine;

        public InterstitialAdSystem()
        {
            _settings = Services.Get<Settings>();
            _ads = Services.Get<IAdsService>();
            _events = Services.Get<EventsMediator>().Ads;
        }

        public override void Init()
        {
            UnityEngine.Debug.Log("Run " + nameof(InterstitialAdSystem));
            RunFirstInterstitialAfterDelay();
            
            _events.RewardedAdsShown += ClearRunnedCooldown;
            _events.InterstitialShown += RunNextInterstitialAfterCooldown;
        }

        public override void Dispose()
        {
            if (_currentCoroutine != null)
                CoroutineLauncher.Stop(_currentCoroutine);
            
            _events.RewardedAdsShown -= ClearRunnedCooldown;
            _events.InterstitialShown -= RunNextInterstitialAfterCooldown;
        }

        private void RunFirstInterstitialAfterDelay()
        {
            UnityEngine.Debug.Log(nameof(RunFirstInterstitialAfterDelay));
            float firstTime = _settings.Ads.FirstInterstitialDelay;
            RunShowAdCoroutine(firstTime);
        }

        private void RunNextInterstitialAfterCooldown(AdsEventType arg1, AdType arg2, string arg3, string arg4) => 
            RunNextInterstitialAfterCooldown();

        private void RunNextInterstitialAfterCooldown()
        {
            UnityEngine.Debug.Log(nameof(RunNextInterstitialAfterCooldown));
            float cooldown = _settings.Ads.InterstitialCooldown;
            RunShowAdCoroutine(cooldown);
        }

        private void RunShowAdCoroutine(float firstTime)
        {
            if (_currentCoroutine != null)
                CoroutineLauncher.Stop(_currentCoroutine);

            _currentCoroutine = CoroutineLauncher.Start(ShowAdAfterDelay(firstTime));
        }

        private IEnumerator ShowAdAfterDelay(float time)
        {
            yield return new WaitForSeconds(time);

            while (!_ads.IsInterstitialReady)
                yield return new WaitForSeconds(1.5f);

            _ads.ShowInterstitial();

            RunNextInterstitialAfterCooldown();
        }

        private void ClearRunnedCooldown(AdsEventType adsEventType, AdType adType, string arg3, string arg4)
        {
            CoroutineLauncher.Stop(_currentCoroutine);
            RunNextInterstitialAfterCooldown();
        }
    }
}