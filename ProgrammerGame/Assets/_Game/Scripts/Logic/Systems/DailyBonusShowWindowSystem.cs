using _Game.Common;
using _Game.Services;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class DailyBonusShowWindowSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.Instance.DailyBonusUpdated += ShowWindow;

        public override void Dispose() => 
            GlobalEvents.Instance.DailyBonusUpdated -= ShowWindow;

        private void ShowWindow() => 
            WindowsManager.Show(SceneObjects.Instance.DailyBonusWindow);
    }
}