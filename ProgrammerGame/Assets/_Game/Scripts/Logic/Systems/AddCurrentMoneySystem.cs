using System.Collections;
using _Game.Common;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
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

            GlobalEvents.ChangeMoneyCount(GameData.Instance.SavableData.MoneyCount, this);
        }
    }
}