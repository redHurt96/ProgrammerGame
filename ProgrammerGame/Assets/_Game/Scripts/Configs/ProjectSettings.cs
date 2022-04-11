using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Project settings", menuName = "Game/Project settings", order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        public string Name;
        public Sprite Icon;

        public int OpenLevel = 0;
        public ProjectSettings BlockProject;

        [SerializeField] private PriceSettings _priceSettings;
        [SerializeField] private PriceSettings _incomeSettings;
        [SerializeField] private TimeSettings _timeSettings;

        public long GetIncome(int forLevel) => _incomeSettings.GetPrice(forLevel);
        public long GetTime(int forLevel) => _timeSettings.GetTime(forLevel);

        public long GetPrice(int level, int count)
        {
            long sum = 0L;

            for (int i = 0; i < count; i++) 
                sum += GetPrice(level + i);

            return sum;
        }

        private long GetPrice(int forLevel) => _priceSettings.GetPrice(forLevel);

#if UNITY_EDITOR
        public void SetPrice(PriceSettings priceSettings) => 
            _priceSettings = priceSettings;
        public void SetIncome(PriceSettings incomeSettings) => 
            _incomeSettings = incomeSettings;
        public void SetTime(TimeSettings timeSettings) => 
            _timeSettings = timeSettings;
#endif
    }
}