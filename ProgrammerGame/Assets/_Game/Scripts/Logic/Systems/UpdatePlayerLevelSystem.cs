using _Game.Common;
using _Game.Data;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class UpdatePlayerLevelSystem : BaseInitSystem
    {
        public override void Init() => 
            GlobalEvents.MoneyCountChanged += UpdateLevel;

        public override void Dispose() => 
            GlobalEvents.MoneyCountChanged -= UpdateLevel;

        private void UpdateLevel(long money)
        {
            if (money <= 0)
                return;

            GameData.Instance.SavableData.TotalEarnedMoney += money;
            int level = GameDataPresenter.Instance.CalculateLevel();

            if (level > GameData.Instance.SavableData.Level)
            {
                GameData.Instance.SavableData.Level = level;
                GlobalEvents.InvokeChangeLevelEvent();
            }
        }
    }
}