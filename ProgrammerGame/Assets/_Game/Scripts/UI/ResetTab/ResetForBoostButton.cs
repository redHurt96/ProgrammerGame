using _Game.Common;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.UI.ResetTab
{
    public class ResetForBoostButton : BaseActionButton
    {
        private EventsMediator _eventsMediator;
        private GameData _data;

        protected override void PerformOnStart()
        {
            _data = Services.Get<GameData>();
            _eventsMediator = Services.Get<EventsMediator>();
        }

        protected override void PerformOnClick()
        {
            float boost = _data.BoostForProgress();
            _eventsMediator.ResetForBoost(boost);
        }
    }
}