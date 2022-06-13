using System.Collections;
using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;

namespace _Game.Logic.Systems
{
    public class UpdatePlayerLevelSystem : BaseInitSystem
    {
        public override void Init() =>
            CoroutineLauncher.Start(DelayedSubscribe());

        public override void Dispose() => 
            EventsMediator.Instance.MoneyCountChanged -= UpdateLevel;

        private IEnumerator DelayedSubscribe()
        {
            yield return null;

            EventsMediator.Instance.MoneyCountChanged += UpdateLevel;
        }
        
        private void UpdateLevel(double money)
        {
            if (money <= 0)
                return;

            GameData.Instance.PersistentData.TotalEarnedMoney += money;
            int level = GameData.Instance.CalculateLevel();

            if (level > GameData.Instance.PersistentData.Level)
            {
                GameData.Instance.PersistentData.Level = level;
                EventsMediator.Instance.InvokeChangeLevelEvent();
            }
        }
    }
}