using _Game.Common;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.UI.ResetTab
{
    public class OpenResetWindowButton : BaseActionButton
    {
        private WindowsManager _windowsManager;

        protected override void PerformOnStart() => 
            _windowsManager = Services.Get<WindowsManager>();

        protected override void PerformOnClick() => 
            _windowsManager.Show(SceneObjects.Instance.ResetWindow);
    }
}