using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Price settings", menuName = "Game/Price settings", order = 0)]
    public class PriceSettingsScriptable : ScriptableObject
    {
        [SerializeField] private float _offset;
        [SerializeField] private float _linear = 1;
        [SerializeField] private float _exponential = 1;
        [SerializeField] private float _additional = 1;

        public long GetPrice(int level) =>
            (long) (_offset + _linear * Mathf.Pow(level, _exponential) * Mathf.Max(1f, level / 25 * _additional));

        public void SetTo(PriceSettings settings)
        {
            settings._offset = _offset;
            settings._linear = _linear;
            settings._exponential = _exponential;
            settings._additional = _additional;
        }
    }
}