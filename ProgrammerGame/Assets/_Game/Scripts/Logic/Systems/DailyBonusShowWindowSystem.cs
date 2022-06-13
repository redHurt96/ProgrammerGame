using _Game.Common;
using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class DailyBonusShowWindowSystem : BaseInitSystem
    {
        private readonly WindowsManager _windowsManager;

        public DailyBonusShowWindowSystem() => 
            _windowsManager = Services.Get<WindowsManager>();

        public override void Init() => 
            EventsMediator.Instance.DailyBonusUpdated += ShowWindow;

        public override void Dispose() => 
            EventsMediator.Instance.DailyBonusUpdated -= ShowWindow;

        private void ShowWindow() => 
            _windowsManager.Show(SceneObjects.Instance.DailyBonusWindow);
    }
}