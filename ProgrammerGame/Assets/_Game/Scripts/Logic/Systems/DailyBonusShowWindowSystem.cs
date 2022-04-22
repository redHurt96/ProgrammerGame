using _Game.Common;
using _Game.Services;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class DailyBonusShowWindowSystem : BaseInitSystem
    {
        public DailyBonusShowWindowSystem()
        {
        }

        public override void Init() => 
            _globalEvents.DailyBonusUpdated += ShowWindow;

        public override void Dispose() => 
            _globalEvents.DailyBonusUpdated -= ShowWindow;

        private void ShowWindow() => 
            WindowsManager.Show(SceneObjects.Instance.DailyBonusWindow);
    }
}