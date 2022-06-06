using _Game.Common;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;

namespace _Game.UI.Ads
{
    public class OpenCoffeeBreakWindowButton : BaseActionButton
    {
        private WindowsManager _windowsManager;
        private SceneObjects _sceneObjects;

        protected override void PerformOnStart()
        {
            _windowsManager = Services.Get<WindowsManager>();
            _sceneObjects = Services.Get<SceneObjects>();
        }

        protected override void PerformOnClick() => 
            _windowsManager.Show(_sceneObjects.CoffeeBreakWindow);
    }
}