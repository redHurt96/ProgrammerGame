using _Game.Common;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ShowLevelWindowSystem : BaseInitSystem
    {
        private readonly GameDataPresenter _gameDataPresenter;

        public ShowLevelWindowSystem()
        {
            _gameDataPresenter = Services.Get<GameDataPresenter>();
        }

        public override void Init() => 
            GlobalEvents.Instance.LevelChanged += ShowRewardWindow;

        public override void Dispose() => 
            GlobalEvents.Instance.LevelChanged -= ShowRewardWindow;

        private void ShowRewardWindow()
        {
            WindowsManager.Show(SceneObjects.Instance.LevelWindow);
            GlobalEvents.Instance.IntentToChangeMoney(_gameDataPresenter.GetRewardForLevel());
        }
    }
}