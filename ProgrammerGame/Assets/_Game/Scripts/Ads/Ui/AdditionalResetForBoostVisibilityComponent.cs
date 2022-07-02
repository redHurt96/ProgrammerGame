using _Game.GameServices;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Ads.Ui
{
    public class AdditionalResetForBoostVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IAdsService _ads;

        private void Start()
        {
            _ads = Services.Get<IAdsService>();
        }

        private void Update() => 
            _button.interactable = _ads.IsRewardedReady;
    }
}