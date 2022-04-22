using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Price settings advanced", menuName = "Game/Price settings advanced", order = 0)]
    public class PriceSettingsScriptableAdvanced : BaseScriptablePriceSettings
    {
        [SerializeField] private PriceSettings _prices;

        public override double GetPrice(int level) => 
            _prices.GetPrice(level);
    }
}