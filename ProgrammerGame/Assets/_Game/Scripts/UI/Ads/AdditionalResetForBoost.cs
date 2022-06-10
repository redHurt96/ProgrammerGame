using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.UI.Ads
{
    public class AdditionalResetForBoost : BaseActionButton
    {
        private IAdsService _ads;
        private GameData _data;
        private Settings _settings;
        private GlobalEvents _events;

        protected override void PerformOnStart()
        {
            _ads = Services.Get<IAdsService>();
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
            _events = Services.Get<GlobalEvents>();
        }

        protected override void PerformOnClick() => 
            _ads.ShowRewarded("Additional boost", PerformOnSuccess);

        private void PerformOnSuccess()
        {
            float boost = _data.BoostForProgress() * _settings.Ads.ResetBoost;
            _events.ResetForBoost(boost);
        }
    }
}