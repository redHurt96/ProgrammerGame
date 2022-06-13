using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.PseudoEcs;

namespace _Game.Logic.Systems
{
    public class AddStartMoneySystem : IInitSystem
    {
        public void Init()
        {
            if (GameData.Instance.SavableData.Projects.All(x => x.State != ProjectState.Active))
                EventsMediator.Instance.IntentToChangeMoney(Settings.Instance.StartMoney);
        }
    }
}