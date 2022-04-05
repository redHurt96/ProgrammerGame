using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Price settings", menuName = "Game/Price settings", order = 0)]
    public class PriceSettings : ScriptableObject
    {
        [SerializeField] private int _offset;

        public long GetPrice(int forLevel) => 
            _offset + forLevel;
    }
}