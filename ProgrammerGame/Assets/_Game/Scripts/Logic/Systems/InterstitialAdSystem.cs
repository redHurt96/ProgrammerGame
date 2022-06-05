using System.Collections;
using _Game.Common;
using _Game.Configs;
using _Game.GameServices;
using RH.Utilities.Coroutines;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class InterstitialAdSystem : BaseInitSystem
    {
        private readonly Settings _settings;
        private readonly AdsService _ads;
        private readonly GlobalEvents _events;

        private Coroutine _currentCoroutine;

        public InterstitialAdSystem()
        {
            _settings = Services.Get<Settings>();
            _ads = Services.Get<AdsService>();
            _events = Services.Get<GlobalEvents>();
        }

        public override void Init()
        {
            RunFirstInterstitialAfterDelay();
            _events.RewardedAdsShown += ClearRunnedCooldown;
        }

        public override void Dispose()
        {
            CoroutineLauncher.Stop(_currentCoroutine);
            _events.RewardedAdsShown -= ClearRunnedCooldown;
        }

        private void RunFirstInterstitialAfterDelay()
        {
            float firstTime = _settings.AdsSettings.FirstInterstitialDelay;
            _currentCoroutine = CoroutineLauncher.Start(ShowAdAfterDelay(firstTime));
        }

        private void RunNextInterstitialAfterCooldown()
        {
            float cooldown = _settings.AdsSettings.InterstitialCooldown;
            _currentCoroutine = CoroutineLauncher.Start(ShowAdAfterDelay(cooldown));
        }

        private IEnumerator ShowAdAfterDelay(float time)
        {
            _ads.LoadInterstitial();
            yield return new WaitForSeconds(time);
            _ads.ShowInterstitial();

            RunNextInterstitialAfterCooldown();
        }

        private void ClearRunnedCooldown()
        {
            CoroutineLauncher.Stop(_currentCoroutine);
            RunNextInterstitialAfterCooldown();
        }
    }
}