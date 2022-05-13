using System.Collections;
using _Game.Common;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;

namespace _Game.Logic.Systems
{
    public class AddCurrentMoneySystem : IInitSystem, IChangeMoneySystem
    {
        public void Init() => 
            CoroutineLauncher.Start(AddMoneyDelayed());

        private IEnumerator AddMoneyDelayed()
        {
            yield return null;

            GlobalEvents.Instance.ChangeMoneyCount(GameData.Instance.SavableData.MoneyCount, this);
        }
    }
}