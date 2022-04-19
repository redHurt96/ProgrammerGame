using System.Collections;
using _Game.Common;
using _Game.Data;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;

namespace _Game.Logic.Systems
{
    public class UpdatePlayerLevelSystem : BaseInitSystem
    {
        public override void Init() =>
            CoroutineLauncher.Start(DelayedSubscribe());

        public override void Dispose() => 
            GlobalEvents.MoneyCountChanged -= UpdateLevel;

        private IEnumerator DelayedSubscribe()
        {
            yield return null;

            GlobalEvents.MoneyCountChanged += UpdateLevel;
        }
        
        private void UpdateLevel(double money)
        {
            if (money <= 0)
                return;

            GameData.Instance.PersistentData.TotalEarnedMoney += money;
            int level = GameDataPresenter.Instance.CalculateLevel();

            if (level > GameData.Instance.PersistentData.Level)
            {
                GameData.Instance.PersistentData.Level = level;
                GlobalEvents.InvokeChangeLevelEvent();
            }
        }
    }
}