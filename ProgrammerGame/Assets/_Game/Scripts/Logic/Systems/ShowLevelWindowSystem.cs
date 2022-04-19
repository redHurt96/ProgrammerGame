using _Game.Common;
using _Game.Services;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class ShowLevelWindowSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.LevelChanged += ShowRewardWindow;

        public override void Dispose() => 
            GlobalEvents.LevelChanged -= ShowRewardWindow;

        private void ShowRewardWindow()
        {
            WindowsManager.Show(SceneObjects.Instance.LevelWindow);
            GlobalEvents.IntentToChangeMoney(GameDataPresenter.Instance.GetRewardForLevel());
        }
    }
}