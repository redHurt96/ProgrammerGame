using _Game.Common;
using _Game.Services;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class ShowLevelWindowSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.Instance.LevelChanged += ShowRewardWindow;

        public override void Dispose() => 
            GlobalEvents.Instance.LevelChanged -= ShowRewardWindow;

        private void ShowRewardWindow()
        {
            WindowsManager.Show(SceneObjects.Instance.LevelWindow);
            GlobalEvents.Instance.IntentToChangeMoney(GameDataPresenter.Instance.GetRewardForLevel());
        }
    }
}