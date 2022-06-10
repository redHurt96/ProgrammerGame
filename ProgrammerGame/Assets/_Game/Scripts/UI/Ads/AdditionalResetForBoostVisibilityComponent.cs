using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Ads
{
    public class AdditionalResetForBoostVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _button;

        private IAdsService _ads;

        private void OnEnable()
        {
            _ads ??= Services.Get<IAdsService>();

            _button.SetActive(_ads.IsRewardedReady);
        }
    }
}