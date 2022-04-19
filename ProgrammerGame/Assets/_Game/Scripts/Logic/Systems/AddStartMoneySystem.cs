using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class AddStartMoneySystem : IInitSystem
    {
        public void Init()
        {
            if (GameData.Instance.SavableData.Projects.All(x => x.State != ProjectState.Active))
                GlobalEvents.Instance.IntentToChangeMoney(Settings.Instance.StartMoney);
        }
    }
}