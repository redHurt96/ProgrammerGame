using _Game.Common;
using _Game.Configs;
using _Game.Scripts.Exception;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Logic.Systems
{
    public class AddMoneyForTapSystem : BaseUpdateSystem
    {
        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsOverUi()) 
                AddMoney();
        }

        private void AddMoney()
        {
            double value = Mathf.Max(1,
                GameDataPresenter.Instance.IncomePerSec * Settings.Instance.MoneyForTapPercent);

            GlobalEvents.Instance.AccelerateCoding(value.ToPriceString());
            GlobalEvents.Instance.IntentToChangeMoney(value);
        }
    }
}