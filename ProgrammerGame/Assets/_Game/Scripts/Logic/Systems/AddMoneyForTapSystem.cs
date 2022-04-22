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
        private GlobalEventsService _globalEvents;
        private GameDataPresenter _gameData;

        public override void Init()
        {
            _globalEvents = Services.Instance.Single<GlobalEventsService>();
            _gameData = Services.Instance.Single<GameDataPresenter>();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsOverUi()) 
                AddMoney();
        }

        private void AddMoney()
        {
            double value = _gameData.MoneyForTap; 

            _globalEvents.AccelerateCoding(value.ToPriceString());
            _globalEvents.IntentToChangeMoney(value);
        }
    }
}