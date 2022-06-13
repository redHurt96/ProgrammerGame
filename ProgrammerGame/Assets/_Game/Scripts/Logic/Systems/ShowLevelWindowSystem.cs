using _Game.Common;
using _Game.Data;
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
            EventsMediator.Instance.LevelChanged += ShowRewardWindow;

        public override void Dispose() => 
            EventsMediator.Instance.LevelChanged -= ShowRewardWindow;

        private void ShowRewardWindow()
        {
            _windowsManager.Show(SceneObjects.Instance.LevelWindow);
            EventsMediator.Instance.IntentToChangeMoney(GameData.Instance.GetRewardForLevel());
        }
    }
}