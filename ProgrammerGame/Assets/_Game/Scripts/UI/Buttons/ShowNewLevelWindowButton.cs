using _Game.Common;
using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.UI.Buttons
{
    public class ShowNewLevelWindowButton : BaseActionButton
    {
        private WindowsManager _windowsManager;

        protected override void PerformOnStart() => 
            _windowsManager = Services.Get<WindowsManager>();

        protected override void PerformOnClick()
        {
            _windowsManager.Show(SceneObjects.Instance.LevelWindow);
            EventsMediator.Instance.IntentToChangeMoney(GameData.Instance.GetRewardForLevel());
            
            gameObject.SetActive(false);
        }
    }
}