using _Game.Common;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ShowLevelWindowSystem : BaseInitSystem
    {
        private readonly WindowsManager _windowsManager;

        public ShowLevelWindowSystem() => 
            _windowsManager = Services.Get<WindowsManager>();
        
        public override void Init() => 
            GlobalEvents.Instance.LevelChanged += ShowRewardWindow;

        public override void Dispose() => 
            GlobalEvents.Instance.LevelChanged -= ShowRewardWindow;

        private void ShowRewardWindow()
        {
            _windowsManager.Show(SceneObjects.Instance.LevelWindow);
            GlobalEvents.Instance.IntentToChangeMoney(GameDataPresenter.Instance.GetRewardForLevel());
        }
    }
}