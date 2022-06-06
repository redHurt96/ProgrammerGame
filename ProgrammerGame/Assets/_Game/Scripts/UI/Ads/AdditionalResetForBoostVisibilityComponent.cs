using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Ads
{
    public class AdditionalResetForBoostVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _button;

        private AdsService _ads;

        private void OnEnable()
        {
            _ads ??= Services.Get<AdsService>();

            _button.SetActive(_ads.IsRewardedReady);
        }
    }
}