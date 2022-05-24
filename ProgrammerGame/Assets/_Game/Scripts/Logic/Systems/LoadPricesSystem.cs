using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class LoadPricesSystem : IInitSystem
    {
        public void Init()
        {
            var service = Services.Get<SaveLoadPricesService>();

            service.Load();
        }
    }
}