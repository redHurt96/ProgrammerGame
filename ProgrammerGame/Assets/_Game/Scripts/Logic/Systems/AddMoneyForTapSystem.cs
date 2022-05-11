using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Scripts.Exception;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Extensions;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Logic.Systems
{
    public class AddMoneyForTapSystem : BaseUpdateSystem
    {
        private readonly GameDataPresenter _gameDataPresenter;

        public AddMoneyForTapSystem()
        {
            _gameDataPresenter = Services.Get<GameDataPresenter>();
        }
        
        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsOverUi()) 
                AddMoney();
        }

        private void AddMoney()
        {
            double value = _gameDataPresenter.MoneyForTap; 

            GlobalEvents.Instance.AccelerateCoding(value.ToPriceString());
            GlobalEvents.Instance.IntentToChangeMoney(value);
        }
    }
}