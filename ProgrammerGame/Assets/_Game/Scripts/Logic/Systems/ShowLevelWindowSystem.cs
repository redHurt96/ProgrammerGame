using _Game.Common;
using _Game.Logic.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ShowLevelWindowSystem : BaseInitSystem
    {
        private readonly GlobalEventsService _globalEvents;
        private readonly GameDataPresenter _gameDataPresenter;
        private readonly WindowsChangeService _windowsChangeService;

        public ShowLevelWindowSystem()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameDataPresenter = Services.Instance.Single<GameDataPresenter>();
            _windowsChangeService = Services.Instance.Single<WindowsChangeService>();
        }

        public override void Init() => 
            _globalEvents.LevelChanged += ShowRewardWindow;

        public override void Dispose() => 
            _globalEvents.LevelChanged -= ShowRewardWindow;

        private void ShowRewardWindow()
        {
            _windowsChangeService.Show(SceneObjects.Instance.LevelWindow);
            _globalEvents.IntentToChangeMoney(_gameDataPresenter.GetRewardForLevel());
        }
    }
}