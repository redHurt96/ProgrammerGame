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
        private Coroutine _routine;
        
        private readonly GameData _data;
        private readonly AdsEvents _events;
        private readonly IAdsService _ads;
        private readonly AdsSettings _settings;

        public CoffeeBreakAdSystem()
        {
            _ads = Services.Get<IAdsService>();
            _data = Services.Get<GameData>();
            _events = Services.Get<EventsMediator>().Ads;
            _settings = Services.Get<Settings>().Ads;
        }

        public override void Init()
        {
            _events.OnCoffeeBreakIntent += ShowAd;

            CoroutineLauncher.Start(DelayUntilNewCoffeeBreak());
        }

        public override void Dispose()
        {
            BreakRoutineIfExist();

            _events.OnCoffeeBreakIntent -= ShowAd;
        }

        private void ShowAd() => 
            _ads.ShowRewarded("CoffeeBreak", PerformOnAdComplete);

        private void PerformOnAdComplete()
        {
            BreakRoutineIfExist();

            _routine = CoroutineLauncher.Start(DelayUntilNewCoffeeBreak());
        }

        private IEnumerator DelayUntilNewCoffeeBreak()
        {
            _data.Ads.CanShowCoffeeBreak = false;
            float boost = _settings.CoffeeBreakBoost;
            ChangeProjectsSpeed(boost);
            _events.StartCoffeeBreak();

            float time = _settings.CoffeeBreakLenght;
            float leftTime = time;

            while (leftTime > 0f)
            {
                _events.CoffeeBreakTimeUpdate(leftTime);
                yield return new WaitForSeconds(1f);
                leftTime -= 1f;
            }

            _events.CompleteCoffeeBreak();
            ChangeProjectsSpeed(1f);

            yield return new WaitForSeconds(_settings.CoffeeBreakDelay);

            while (!_ads.IsRewardedReady)
                yield return new WaitForSeconds(_settings.CoffeeBreakDelay);

            _data.Ads.CanShowCoffeeBreak = true;
            _events.ReloadCoffeeBreak();
        }

        private void ChangeProjectsSpeed(float boost)
        {
            foreach (ProjectData project in _data.GetActiveProjects())
                project.ChangeSpeedBoost(boost);
        }

        private void BreakRoutineIfExist()
        {
            if (_routine != null)
                CoroutineLauncher.Stop(_routine);
        }
    }
}