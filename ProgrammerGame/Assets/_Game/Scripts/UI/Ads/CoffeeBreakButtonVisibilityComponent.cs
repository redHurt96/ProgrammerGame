using _Game.Data;
using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Ads
{
    public class CoffeeBreakButtonVisibilityComponent : MonoBehaviour
    {
        private GameData _data;
        private AdsService _ads;

        private void Start()
        {
            _data = Services.Get<GameData>();
            _ads = Services.Get<AdsService>();
        }

        private void Update() => 
            gameObject.SetActive(_data.Ads.CanShowCoffeeBreak && _ads.IsRewardedReady);
    }
}