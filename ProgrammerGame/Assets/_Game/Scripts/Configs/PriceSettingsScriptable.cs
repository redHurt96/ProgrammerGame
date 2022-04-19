using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Price settings", menuName = "Game/Price settings", order = 0)]
    public class PriceSettingsScriptable : ScriptableObject
    {
        [SerializeField] private double[] _prices;

        public double GetPrice(int level) => 
            _prices[level];
    }
}