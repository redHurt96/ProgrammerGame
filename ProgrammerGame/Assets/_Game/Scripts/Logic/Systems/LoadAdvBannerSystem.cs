using _Game.GameServices;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class LoadAdvBannerSystem : IInitSystem
    {
        private readonly IAdsService _ads;

        public LoadAdvBannerSystem() => 
            _ads = Services.Get<IAdsService>();

        public void Init() => 
            _ads.LoadBanner();
    }
}